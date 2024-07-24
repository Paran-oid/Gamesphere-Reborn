using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Achievements", Schema = "gam")]
    public class Achievement
    {
        [SetsRequiredMembers]
        public Achievement()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PicturePath { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey("ID")]
        public int GameID { get; set; }

        public Game Game { get; set; }
    }
}