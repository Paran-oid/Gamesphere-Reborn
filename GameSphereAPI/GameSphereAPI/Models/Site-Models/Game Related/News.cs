using GameSphereAPI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("News", Schema = "gam")]
    public class News
    {
        [SetsRequiredMembers]
        public News()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        [ForeignKey("ID")]
        public int GameID { get; set; }

        public Game Game { get; set; }

        [ForeignKey("ID")]
        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }
    }
}