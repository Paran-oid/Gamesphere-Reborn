using GameSphereAPI.Data;
using GameSphereAPI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using GameSphereAPI.Data.Services.Cache;
using GameSphereAPI.Data.Services.GameServices;
using GameSphereAPI.Data.Services.LanguageServices;
using GameSphereAPI.Data.Services.PublisherServices;
using Serilog;
using GameSphereAPI.Utilities.Background;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Hangfire.PostgreSql;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization using bearer token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

//Identity
//verifying someone is the person that he says they are
//Added JWT tokens too
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:SecretKey").Value)),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/UserRegistration/Login";
    options.SlidingExpiration = true;
});
//process of verifying that someone has access to an account
builder.Services.AddAuthorization();
//in real life projects store these tokens in service specific design for storing tokens
builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//AppServices
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

//Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Utilities/Logs/LogDay.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.File("Utilities/Logs/LogMonth.txt", rollingInterval: RollingInterval.Month)
    .WriteTo.File("Utilities/Logs/LogYear.txt", rollingInterval: RollingInterval.Year)
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

//Hangfire
builder.Services.AddHostedService<AppBackgroundService>();

builder.Services.AddHangfire(x =>
{
    x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Default"));
});


//Cores so the application could work
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Logger
app.UseSerilogRequestLogging();

//HangFire Dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "GameSphere",
    DarkModeEnabled = true,
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User = "admin",
            Pass = "admin123"
        }
    }
});

app.Run();

public partial class Program { }