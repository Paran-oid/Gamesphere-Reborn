using System.ComponentModel.DataAnnotations.Schema;
using GameSphereAPI.Models.User.Relationships;

namespace GameSphereAPI.Models.User.Group_Related
{
    [Table("Groups", Schema = "grp")]
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string Description { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}