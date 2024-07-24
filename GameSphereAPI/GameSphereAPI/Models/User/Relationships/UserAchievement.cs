using GameSphereAPI.Models.Site_Models.Game_Related;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.User.Relationships
{
    [Table("UserAchievements", Schema = "usr")]
    public class UserAchievement
    {
        [ForeignKey("ID")]
        public int ID { get; set; }

        public Achievement Achievement { get; set; }

        public bool IsAchieved { get; set; }
        public UserGame Game { get; set; }
    }
}