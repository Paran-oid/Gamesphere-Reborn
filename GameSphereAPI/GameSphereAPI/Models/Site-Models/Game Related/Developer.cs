﻿using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using GameSphereAPI.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Developers", Schema = "gam")]
    public class Developer
    {
        [SetsRequiredMembers]
        public Developer()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "numeric(3, 2)")]
        public decimal Rating { get; set; }

        [ForeignKey("ID")]
        public string AppUserID { get; set; } = string.Empty;

        public AppUser AppUser { get; set; }

        public ICollection<GameDeveloper> GameDeveloper { get; set; }
    }
}