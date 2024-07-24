using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameSphereAPI.Models.Viewmodels.Registration___Authentication
{
    public class AppLoginRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = ("Must be at least 8 characters"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}