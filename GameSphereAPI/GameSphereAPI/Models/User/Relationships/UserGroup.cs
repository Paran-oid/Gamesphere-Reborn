using System.ComponentModel.DataAnnotations.Schema;
using GameSphereAPI.Models.User.Group_Related;

namespace GameSphereAPI.Models.User.Relationships
{
    [Table("UserGroups", Schema = "usg")]
    public class UserGroup
    {
        public string UserID { get; set; }
        public AppUser User { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}