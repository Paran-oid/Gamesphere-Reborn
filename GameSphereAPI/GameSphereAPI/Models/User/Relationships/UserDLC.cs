using GameSphereAPI.Models.Site_Models.Game_Related;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.User.Relationships
{
    [Table("UserDLCs", Schema = "usr")]
    public class UserDLC
    {
        [ForeignKey("ID")]
        public int ID { get; set; }

        public DLC DLC { get; set; }

        public bool HasDLC { get; set; }
        public DateTime DatePurchased { get; set; }
        public UserGame Game { get; set; }
    }
}