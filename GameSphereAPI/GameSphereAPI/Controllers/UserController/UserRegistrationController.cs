using GameSphereAPI.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using GameSphereAPI.Models.Viewmodels.Registration;
using GameSphereAPI.Models.Viewmodels.Registration___Authentication;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using GameSphereAPI.Models.Viewmodels.User_Informations___Other;
using GameSphereAPI.Data.Services.Cache;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using GameSphereAPI.Controllers.Extra;

namespace GameSphereAPI.Controllers.UserController
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private static readonly EmailAddressAttribute _emailAddressAttribute = new();
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly TimeProvider _timeProvider;
        private readonly IEmailSender<AppUser> _emailSender;
        private readonly IConfiguration _configuration;
        private readonly LinkGenerator _linkGenerator;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public UserRegistrationController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            TimeProvider timeProvider,
            IEmailSender<AppUser> emailSender,
            LinkGenerator linkGenerator,
            IConfiguration configuration,
            ICacheService cacheService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _timeProvider = timeProvider;
            _emailSender = emailSender;
            _linkGenerator = linkGenerator;
            _configuration = configuration;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AppUser>> GetUser()
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userID);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return new AppUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Birth = user.Birth,
                    Email = user.Email,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Location = user.Location,
                    PasswordHash = user.PasswordHash
                };
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] AppRegisterRequest registration)
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException($"{nameof(UserRegistrationController)} requires a user store with email support.");
            }

            var username = registration.Username;
            var email = registration.Email;

            if (string.IsNullOrEmpty(email) || !_emailAddressAttribute.IsValid(email))
            {
                return BadRequest("Invalid email format.");
            }

            //map registration content to appuser himself
            var user = _mapper.Map<AppUser>(registration);

            var result = await _userManager.CreateAsync(user, registration.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
            {
                return Conflict(result.Errors);
            }
            var token = GenerateToken(user);

            return Ok(token);
        }

        [HttpPost]
        public async Task<ActionResult<AccessTokenResponse>> Login([FromBody] Models.Viewmodels.Registration___Authentication.LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)
        {
            var useCookieScheme = useCookies == true || useSessionCookies == true;
            var isPersistent = useCookies == true && useSessionCookies != true;

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == login.UsernameOrEmail || u.Email == login.UsernameOrEmail);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, isPersistent, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                // Generate JWT token
                var token = GenerateToken(user); // Implement this method to generate JWT token

                return Ok(new AccessTokenResponse
                {
                    AccessToken = token,
                    ExpiresIn = (int)(DateTime.UtcNow.AddDays(1) - DateTime.UtcNow).TotalSeconds,
                });
            }

            return Conflict("Invalid credentials");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            bool authenticated = User.Identity.IsAuthenticated;

            if (!authenticated)
            {
                return Unauthorized();
            }

            await _signInManager.SignOutAsync();

            return Ok($"you have logged out");
        }

        [HttpPost]
        private string GenerateToken(AppUser user)
        {
            //We create a claim list that contains the name of user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            //We get the key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:SecretKey").Value));

            //We use the algorithm needed for the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //We create our token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            //We write the token and then return it
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> SendConfirmationEmailAsync(string email, bool isChange = false)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var code = isChange
                ? await _userManager.GenerateChangeEmailTokenAsync(user, email)
                : await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var userId = await _userManager.GetUserIdAsync(user);

            var confirmationLink = Url.Action("ConfirmEmail", "UserRegistration", new { userId, code }, Request.Scheme);

            string body = $"<html>" +
                          $"<body>" +
                          $"<p> Hello {user.UserName}, We welcome you to GameSphere :)</p>" +
                          $"<p><a href='{confirmationLink}'>Click here to verify your mail</a></p>" +
                          $"<p>Once you confirm your email you will be able to modify your account and access all features this website offers.</p>" +
                          $"</body>" +
                          $"</html>";

            string subject = "Confirm Email";

            bool res = EmailSender.SendMail(
                "zoidorganization@gmail.com",
                "ndyesmglgtvyvwmk",
                "Zoid",
                user.Email,
                user.UserName,
                body,
                subject
                );
            //make sure this works

            return Ok($"We sent you a mail to verify your account!");
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                // Handle missing userId or code
                return Unauthorized();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // Handle user not found
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            if (user.EmailConfirmed)
            {
                return Ok("Your email is already confirmed");
            }

            // Decode the code
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            // Confirm the user's email
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                // Handle confirmation failure
                return BadRequest($"Error confirming email for user with ID '{userId}'.");
            }

            // Handle successful confirmation (e.g., redirect to a success page)
            return Ok("Thank you for confirming your email. Your email is now verified.");
        }

        //Forgot password
        [HttpGet]
        public async Task<ActionResult> GeneratePasswordCode([FromHeader] string userID)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID);

            if (user == null)
            {
                return NotFound("We couldn't find the user");
            }

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(code);
        }

        [HttpPost]
        public async Task<ActionResult<string>> SendPasswordReset([FromBody] EntryRequest model)
        {
            var user = await _userManager.Users.Where(u => u.Email == model.entry).FirstOrDefaultAsync();
            string op = "email";
            if (user == null)
            {
                user = await _userManager.Users.Where(u => u.PhoneNumber == model.entry).FirstOrDefaultAsync();
                if (user == null)
                {
                    return NotFound("We couldn't find your account we are sorry");
                }

                if (!user.PhoneNumber.StartsWith('+'))
                {
                    return Conflict("There was an error using your number");
                }
                op = "phone";
            }
            switch (op)
            {
                case "email":
                    string code = await _userManager.GeneratePasswordResetTokenAsync(user);

                    string body = $"<html>" +
                                  $"<body>" +
                                  $"<p>On {DateTime.Now}, you requested a password reset:</p>" +
                                  $"<p>{code}</p>" +
                                  $"<p>If this wasn't you, do not bother with it</p>" +
                                  $"</body>" +
                                  $"</html>";

                    string subject = "Password Reset";

                    bool res = EmailSender.SendMail(
                        "zoidorganization@gmail.com",
                        "ndyesmglgtvyvwmk",
                        "Zoid",
                        user.Email,
                        user.UserName,
                        body,
                        subject
                        );

                    if (res == true)
                    {
                        //return link next time
                        return Ok("We sent you an email with link to the password reset page");
                    }
                    else
                    {
                        return Conflict("There was an issue sending you the email");
                    }

                case "phone":

                    Random random = new Random();
                    code = random.Next(1000, 10000).ToString();

                    var accountSid = _configuration.GetSection("SMS:TwilioAccountSid").Value;
                    var authToken = _configuration.GetSection("SMS:AuthToken").Value;
                    TwilioClient.Init(accountSid, authToken);

                    var To = user.PhoneNumber;
                    var From = _configuration.GetSection("SMS:Sender").Value;

                    var message = MessageResource.Create(
                        to: To,
                        from: From,
                        body: $"Hello {user.UserName}! here is your code:\n {code}");

                    //Cache code to use it for verification
                    DateTimeOffset expires = DateTimeOffset.Now.AddMinutes(30);
                    _cacheService.SetData($"{user.UserName} code", code, expires);

                    return Ok("We sent you an sms with your code!");

                default:
                    return Conflict("Error interpreting your email/phone");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> EnterPhoneCode(string userID, string code)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID);

            var ourCode = _cacheService.GetData<string>($"{user.UserName} code");
            if (ourCode != code)
            {
                return BadRequest("Please enter the correct code");
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            _cacheService.RemoveData($"{user.UserName} code");

            //return link next time
            return Ok(token);
        }

        [HttpPost]
        public async Task<ActionResult<string>> ResetPassword([FromHeader] string userID, [FromHeader] string code, [FromBody] ResetPasswordRegistration model)
        {
            if (userID == null || code == null)
            {
                return Unauthorized();
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userID}'.");
            }

            // Decode the code

            if (model.NewPassword != model.ResetPassword)
            {
                return BadRequest("Please enter the same password");
            }

            var result = await _userManager.ResetPasswordAsync(user, code, model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return "You have changed your password!";
        }

        //IMPLEMENT SEND PHONE ADDITION
        [HttpGet]
        public async Task<ActionResult<string>> SendPhoneAdditionRequest(string userID, string phoneNumber)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID);
            if (user == null)
            {
                return NotFound("Sorry we couldn't find you");
            }
            if (!phoneNumber.StartsWith('+'))
            {
                return BadRequest();
            }
            Random random = new Random();
            int number = random.Next(1000, 10000);

            var accountSid = _configuration.GetSection("SMS:TwilioAccountSid").Value;
            var authToken = _configuration.GetSection("SMS:AuthToken").Value;
            TwilioClient.Init(accountSid, authToken);

            var To = user.PhoneNumber;
            var From = _configuration.GetSection("SMS:Sender").Value;

            var message = MessageResource.Create(
                to: To,
                from: From,
                body: $"Hello {user.UserName}! here is your code:\n {number}");

            //Cache code to use it for verification
            DateTimeOffset expires = DateTimeOffset.Now.AddMinutes(30);
            _cacheService.SetData($"{user.UserName} add phone number", number, expires);
            return Ok("We sent you an sms with your code!");
        }

        [HttpPost]
        public async Task<ActionResult<string>> PhoneAddition(string userID, int code, string phone)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID);

            if (user == null)
            {
                return NotFound();
            }

            var data = _cacheService.GetData<int>($"{user.UserName} add phone number");
            if (data == code)
            {
                await _userManager.SetPhoneNumberAsync(user, phone);
            }

            return Ok($"{phone} was added to your account");
        }

        //IMPLEMENT OAUTH2 STUFF
    }
}