using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related.Relationships
{
    [Table("GameTags", Schema = "gam")]
    public class GameTag
    {
        [SetsRequiredMembers]
        public GameTag()
        {
        }

        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}