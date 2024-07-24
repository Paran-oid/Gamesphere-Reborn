using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.Viewmodels.Registration___Authentication
{
    public sealed class LoginRequest
    {
        [Column(name: "Username/Email")]
        public string UsernameOrEmail { get; init; }

        [Required]
        [MinLength(8, ErrorMessage = ("Must be at least 8 characters"))]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        public string? TwoFactorCode { get; init; }
        public string? TwoFactorRecoveryCode { get; init; }
    }
}