using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using GameSphereAPI.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GameSphereAPI.Data
{
    public class AppDbContextSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedGenres(modelBuilder);
            SeedLanguages(modelBuilder);
            SeedPublishers(modelBuilder);
            SeedDevelopers(modelBuilder);
            SeedTags(modelBuilder);
            SeedGames(modelBuilder);
            SeedRelationships(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>()
                .HasData(
                new AppRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = "2", Name = "Publisher", NormalizedName = "PUBLISHER" },
                new AppRole { Id = "3", Name = "Developer", NormalizedName = "DEVELOPER" },
                new AppRole { Id = "4", Name = "User", NormalizedName = "USER" });
        }

        private static void SeedGenres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { ID = 1, Name = "Action" },
                new Genre { ID = 2, Name = "Adventure" },
                new Genre { ID = 3, Name = "Role-playing" }
            );
        }

        private static void SeedLanguages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { ID = 1, Name = "English" },
                new Language { ID = 2, Name = "French" },
                new Language { ID = 3, Name = "Spanish" }
            );
        }

        private static void SeedPublishers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { ID = 1, Name = "Publisher X", Rating = 2.1M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" },
                new Publisher { ID = 2, Name = "Publisher Y", Rating = 3.8M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" },
                new Publisher { ID = 3, Name = "Publisher Z", Rating = 4.2M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" }
            );
        }

        private static void SeedDevelopers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(
                new Developer { ID = 1, Name = "Developer X", Rating = 4.2M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" },
                new Developer { ID = 2, Name = "Developer Y", Rating = 4.1M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" },
                new Developer { ID = 3, Name = "Developer Z", Rating = 4.3M, AppUserID = "0b8cff9b-07a7-40ba-973a-ccb0cd04927e" }
              );
        }

        private static void SeedTags(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "Action" },
                new Tag { ID = 2, Name = "Adventure" },
                new Tag { ID = 3, Name = "RPG" }
            );
        }

        private static void SeedGames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    ID = 1,
                    Title = "Sample Game 1",
                    BackgroundPath = "/path/to/background1.jpg",
                    TrailerPath = "/path/to/trailer1.mp4",
                    PicturesPaths = new List<string> { "/path/to/picture1.jpg", "/path/to/picture2.jpg" },
                    ReleaseDate = new DateOnly(2023, 1, 15),
                    SysReq = "Sample system requirements for Game 1.",
                    Price = 49.99m,
                    Size = "15.5m",
                    Description = "Sample description for Game 1."
                },
                new Game
                {
                    ID = 2,
                    Title = "Sample Game 2",
                    BackgroundPath = "/path/to/background2.jpg",
                    TrailerPath = "/path/to/trailer2.mp4",
                    PicturesPaths = new List<string> { "/path/to/picture3.jpg", "/path/to/picture4.jpg" },
                    ReleaseDate = new DateOnly(2023, 3, 20),
                    SysReq = "Sample system requirements for Game 2.",
                    Price = 39.99m,
                    Size = "12.0m",
                    Description = "Sample description for Game 2."
                }
                // Add more games as needed
            );
        }

        private static void SeedRelationships(ModelBuilder builder)
        {
            builder.Entity<GameGenre>()
        .HasData(
            new GameGenre { GameID = 1, GenreID = 1 },
            new GameGenre { GameID = 1, GenreID = 2 },
            new GameGenre { GameID = 2, GenreID = 2 },
            new GameGenre { GameID = 2, GenreID = 3 }
        );

            // Seed GameLanguages (Relationships)
            builder.Entity<GameLanguage>()
                .HasData(
                    new GameLanguage { GameID = 1, LanguageID = 1 },
                    new GameLanguage { GameID = 1, LanguageID = 2 },
                    new GameLanguage { GameID = 2, LanguageID = 2 },
                    new GameLanguage { GameID = 2, LanguageID = 3 }
                );

            // Seed GameTags (Relationships)
            builder.Entity<GameTag>()
                .HasData(
                    new GameTag { GameID = 1, TagID = 1 },
                    new GameTag { GameID = 1, TagID = 2 },
                    new GameTag { GameID = 2, TagID = 2 },
                    new GameTag { GameID = 2, TagID = 3 }
                );

            //Seed GameDevelopers (Relationships)
            builder.Entity<GameDeveloper>()
                .HasData(
                    new GameDeveloper { GameID = 1, DeveloperID = 1 },
                    new GameDeveloper { GameID = 1, DeveloperID = 2 },
                    new GameDeveloper { GameID = 2, DeveloperID = 2 },
                    new GameDeveloper { GameID = 2, DeveloperID = 3 }
                );
        }
    }
}