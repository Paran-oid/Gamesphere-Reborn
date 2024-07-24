using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Genres", Schema = "gam")]
    public class Genre
    {
        [SetsRequiredMembers]
        public Genre()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}