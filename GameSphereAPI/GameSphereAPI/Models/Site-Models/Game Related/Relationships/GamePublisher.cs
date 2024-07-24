using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related.Relationships
{
    [Table("GamePublishers", Schema = "gam")]
    public class GamePublisher
    {
        [SetsRequiredMembers]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GamePublisher()
        {
        }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}