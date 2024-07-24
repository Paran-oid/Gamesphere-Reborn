using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace GameSphereAPI.Models.Viewmodels.Registration
{
    public class AppRegisterRequest
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateOnly Birth { get; set; }
        public string Location { get; set; }
        [MinLength(3, ErrorMessage = "Must have at least 3 characters")]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = ("Must be at least 8 characters"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}