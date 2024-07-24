using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameSphereAPI.Models.Viewmodels.User_Informations___Other.New_Password
{
    public class PasswordRequest
    {
        public string PhoneOrEmail { get; set; }

        [MinLength(8)]
        [PasswordPropertyText]
        public string NewPassword { get; set; }

        public string RepeatedPassword { get; set; }
    }
}