using GameSphereAPI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Reviews", Schema = "gam")]
    public class Review
    {
        public int ID { get; set; }
        public string? Content { get; set; } = string.Empty;
        public int Likes { get; set; }

        [ForeignKey("ID")]
        public string UserID { get; set; } = string.Empty;

        public required AppUser User { get; set; }

        [ForeignKey("ID")]
        public int GameID { get; set; }

        public required Game Game { get; set; }
    }
}