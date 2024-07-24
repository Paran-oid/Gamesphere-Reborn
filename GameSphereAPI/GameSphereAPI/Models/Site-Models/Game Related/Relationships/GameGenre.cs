using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related.Relationships
{
    [Table("GameGenres", Schema = "gam")]
    public class GameGenre
    {
        [SetsRequiredMembers]
        public GameGenre()
        {
        }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}