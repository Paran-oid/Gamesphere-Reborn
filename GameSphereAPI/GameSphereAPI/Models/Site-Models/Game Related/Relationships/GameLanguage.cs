using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related.Relationships
{
    [Table("GameLanguages", Schema = "gam")]
    public class GameLanguage
    {
        [SetsRequiredMembers]
        public GameLanguage()
        {
        }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public int GameID { get; set; }

        public Game Game { get; set; }
    }
}