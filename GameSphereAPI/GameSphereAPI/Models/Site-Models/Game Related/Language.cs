using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Languages", Schema = "gam")]
    public class Language
    {
        [SetsRequiredMembers]
        public Language()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<GameLanguage> GameLanguages { get; set; }
    }
}