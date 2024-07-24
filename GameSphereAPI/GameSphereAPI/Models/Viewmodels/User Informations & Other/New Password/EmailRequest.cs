using System.ComponentModel.DataAnnotations;

namespace GameSphereAPI.Models.Viewmodels.User_Informations___Other.New_Password
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}