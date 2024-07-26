using GameSphereAPI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Reviews", Schema = "gam")]
    public class Review
    {
        public Review()
        {
        }

        public int ID { get; set; }
        public string? Content { get; set; } = string.Empty;
        public int Likes { get; set; }

        [ForeignKey("ID")]
        public string AppUserID { get; set; } = string.Empty;

        [JsonIgnore]
        public AppUser User { get; set; }

        [ForeignKey("ID")]
        public int GameID { get; set; }

        public Game Game { get; set; }
    }
}