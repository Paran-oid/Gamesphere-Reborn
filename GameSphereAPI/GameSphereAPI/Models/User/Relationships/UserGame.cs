using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.User.Relationships
{
    [Table("UserGames", Schema = "usr")]
    public class UserGame
    {
        public int ID { get; set; }
        public decimal? HoursPlayed { get; set; }
        public DateOnly? LastTimePlayed { get; set; }
        public List<UserAchievement>? Achievements { get; set; }
        public List<UserDLC>? DLC { get; set; }
    }
}