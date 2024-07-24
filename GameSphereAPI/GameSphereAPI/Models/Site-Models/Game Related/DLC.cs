using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("DLCs", Schema = "gam")]
    public class DLC
    {
        [SetsRequiredMembers]
        public DLC()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        [ForeignKey("ID")]
        public int GameID { get; set; }

        public Game Game { get; set; }
    }
}