using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using GameSphereAPI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Publishers", Schema = "gam")]
    public class Publisher
    {
        [SetsRequiredMembers]
        public Publisher()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "numeric(3, 2)")]
        public decimal Rating { get; set; }

        [ForeignKey("ID")]
        public string AppUserID { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }

        [JsonIgnore]
        public ICollection<GamePublisher> GamePublishers { get; set; }
    }
}