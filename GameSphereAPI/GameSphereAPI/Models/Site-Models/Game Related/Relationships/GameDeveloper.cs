using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related.Relationships
{
    [Table("GameDevelopers", Schema = "gam")]
    public class GameDeveloper
    {
        [SetsRequiredMembers]
        public GameDeveloper()
        {
        }

        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}