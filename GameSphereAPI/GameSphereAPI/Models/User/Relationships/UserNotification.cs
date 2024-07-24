using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.User.Relationships
{
    [Table("UserNotification", Schema = "usr")]
    public class UserNotification
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser User { get; set; }
    }
}