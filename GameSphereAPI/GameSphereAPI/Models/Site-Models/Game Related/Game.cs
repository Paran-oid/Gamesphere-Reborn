using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GameSphereAPI.Models.Site_Models.Game_Related
{
    [Table("Games", Schema = "gam")]
    public class Game
    {
        [SetsRequiredMembers]
        public Game()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string BackgroundPath { get; set; } = string.Empty;
        public string TrailerPath { get; set; } = string.Empty;
        public List<string> PicturesPaths { get; set; }
        public DateOnly ReleaseDate { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal Price { get; set; }

        public string Size { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string SysReq { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Achievement>? Achievements { get; set; }

        [JsonIgnore]
        public List<DLC>? DLCs { get; set; }

        [JsonIgnore]
        public List<Language> Languages { get; set; }

        [JsonIgnore]
        public List<News>? News { get; set; }

        [JsonIgnore]
        public List<Publisher> Publishers { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; }

        [JsonIgnore]
        public ICollection<GamePublisher> GamePublishers { get; set; }
        [JsonIgnore]
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
        [JsonIgnore]
        public ICollection<GameGenre> GameGenres { get; set; }
        [JsonIgnore]
        public ICollection<GameLanguage> GameLanguages { get; set; }
        [JsonIgnore]
        public ICollection<GameTag> GameTags { get; set; }
    }
}