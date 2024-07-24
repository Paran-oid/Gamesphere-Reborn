using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Tags", Schema = "gam")]
    public class Tag
    {
        [SetsRequiredMembers]
        public Tag()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<GameTag> GameTags { get; set; }
    }
}