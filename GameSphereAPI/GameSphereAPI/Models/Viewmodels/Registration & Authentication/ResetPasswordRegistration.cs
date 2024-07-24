using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameSphereAPI.Models.Viewmodels.Registration___Authentication
{
    public class ResetPasswordRegistration
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        public string ResetPassword { get; set; }
    }
}