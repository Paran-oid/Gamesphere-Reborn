using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.User;
using Microsoft.EntityFrameworkCore;
using GameSphereAPI.Models.User.Relationships;
using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;

namespace GameSphereAPI.Data
{
    public class AppDbContextConfig
    {
        public static void program(ModelBuilder builder)
        {
            //appuser, developer and publisher config
            builder.Entity<Developer>()
                .HasIndex(u => u.AppUserID)
                .IsUnique();

            builder.Entity<Publisher>()
                .HasIndex(u => u.AppUserID)
                .IsUnique();


            //game config

            builder.Entity<GameGenre>()
                .HasKey(g => new { g.GenreID, g.GameID });

            builder.Entity<GameGenre>()
                .HasOne(g => g.Game)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(g => g.GameID);

            builder.Entity<GameGenre>()
                .HasOne(g => g.Genre)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(g => g.GenreID);

            // GameLanguage Configuration
            builder.Entity<GameLanguage>()
                .HasKey(gl => new { gl.LanguageID, gl.GameID });

            builder.Entity<GameLanguage>()
                .HasOne(gl => gl.Game)
                .WithMany(g => g.GameLanguages)
                .HasForeignKey(gl => gl.GameID);

            builder.Entity<GameLanguage>()
                .HasOne(gl => gl.Language)
                .WithMany(l => l.GameLanguages)
                .HasForeignKey(gl => gl.LanguageID);

            // GameTag Configuration
            builder.Entity<GameTag>()
                .HasKey(gt => new { gt.TagID, gt.GameID });

            builder.Entity<GameTag>()
                .HasOne(gt => gt.Game)
                .WithMany(g => g.GameTags)
                .HasForeignKey(gt => gt.GameID);

            builder.Entity<GameTag>()
                .HasOne(gt => gt.Tag)
                .WithMany(t => t.GameTags)
                .HasForeignKey(gt => gt.TagID);

            // GamePublisher Configuration
            builder.Entity<GamePublisher>()
                .HasKey(gp => new { gp.PublisherID, gp.GameID });

            builder.Entity<GamePublisher>()
                .HasOne(gp => gp.Publisher)
                .WithMany(gp => gp.GamePublishers)
                .HasForeignKey(gp => gp.PublisherID);

            builder.Entity<GamePublisher>()
                .HasOne(gp => gp.Game)
                .WithMany(gp => gp.GamePublishers)
                .HasForeignKey(gp => gp.PublisherID);

            // GameDeveloper Configuration
            builder.Entity<GameDeveloper>()
                .HasKey(gt => new { gt.DeveloperID, gt.GameID });

            builder.Entity<GameDeveloper>()
                .HasOne(gt => gt.Developer)
                .WithMany(gt => gt.GameDeveloper)
                .HasForeignKey(gt => gt.DeveloperID);

            builder.Entity<GameDeveloper>()
                .HasOne(gt => gt.Game)
                .WithMany(gt => gt.GameDevelopers)
                .HasForeignKey(gt => gt.GameID);

            //user config
            builder.Entity<AppUser>()
                .HasOne(u => u.FavoriteGroup);

            builder.Entity<AppUser>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            //user group config
            builder.Entity<UserGroup>()
                .HasKey(u => new { u.UserID, u.GroupID });

            builder.Entity<UserGroup>()
                .HasOne(g => g.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(g => g.GroupID);

            builder.Entity<UserGroup>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(u => u.UserID);

            //user notification config
        }
    }
}