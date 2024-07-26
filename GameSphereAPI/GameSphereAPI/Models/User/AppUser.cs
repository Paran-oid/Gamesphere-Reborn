using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.User.Group_Related;
using GameSphereAPI.Models.User.Relationships;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.User
{
    public class AppUser : IdentityUser
    {
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public DateOnly Birth { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Nickname { get; set; }
        public string? Summary { get; set; }
        public string? ProfilePicturePath { get; set; }
        public List<Review>? Reviews { get; set; }
        public Group? FavoriteGroup { get; set; }
        public ICollection<UserGroup>? UserGroups { get; set; }
        public List<UserGame>? UserGames { get; set; }
        public List<UserNotification>? UserNotifications { get; set; }
    }
}