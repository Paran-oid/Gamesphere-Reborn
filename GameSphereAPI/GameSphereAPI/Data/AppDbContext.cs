using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using GameSphereAPI.Models.Site_Models.Shopping_Related;
using GameSphereAPI.Models.User;
using GameSphereAPI.Models.User.Relationships;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSphereAPI.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppDbContextConfig.program(builder);

            AppDbContextSeeder.SeedData(builder);

            base.OnModelCreating(builder);
        }

        // Site-Models -> Game Related
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<DLC> DLCs { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<GamePublisher> GamePublishers { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GameLanguage> GameLanguages { get; set; }
        public DbSet<GameTag> GameTags { get; set; }

        // Site-Models -> Shopping Related
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        // User -> Group Related
        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserDLC> UserDLCs { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        // User -> Relationships
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}