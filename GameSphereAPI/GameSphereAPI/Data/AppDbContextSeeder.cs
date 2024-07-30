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
            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedGenres(modelBuilder);
            SeedLanguages(modelBuilder);
            SeedPublishers(modelBuilder);
            SeedDevelopers(modelBuilder);
            SeedTags(modelBuilder);
            SeedGames(modelBuilder);
            SeedRelationships(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                 .HasData(new AppUser
                 {
                     Id = "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                     UserName = "user1@example.com",
                     Email = "user1@example.com",
                     Fname = "John",
                     Lname = "Doe",
                     Birth = new DateOnly(1990, 1, 1),
                     Location = "New York",
                     Nickname = "Johnny",
                     Summary = "A gamer",
                     ProfilePicturePath = "/images/user1.jpg"
                 },
                new AppUser
                {
                    Id = "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                    UserName = "user2@example.com",
                    Email = "user2@example.com",
                    Fname = "Jane",
                    Lname = "Doe",
                    Birth = new DateOnly(1992, 2, 2),
                    Location = "Los Angeles",
                    Nickname = "Janie",
                    Summary = "Another gamer",
                    ProfilePicturePath = "/images/user2.jpg"
                });
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
                new Publisher { ID = 1, Name = "Publisher X", Rating = 2.1M, AppUserID = "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5" },
                new Publisher { ID = 2, Name = "Publisher Y", Rating = 3.8M, AppUserID = "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d" }
            );
        }

        private static void SeedDevelopers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(
                new Developer { ID = 1, Name = "Developer X", Rating = 4.2M, AppUserID = "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5" },
                new Developer { ID = 2, Name = "Developer Y", Rating = 4.1M, AppUserID = "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d" }
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
                    Title = "Hearts of Iron 4",
                    BackgroundPath = "/path/to/background1.jpg",
                    TrailerPath = "/path/to/trailer1.mp4",
                    PicturesPaths = new List<string> { "/GameImages/hoi4.jpg", "/path/to/picture2.jpg" },
                    ReleaseDate = new DateOnly(2023, 1, 15),
                    SysReq = "Sample system requirements for Game 1.",
                    Price = 29.99m,
                    Size = "15.5m",
                    Description = "Sample description for Game 1."
                },
                new Game
                {
                    ID = 2,
                    Title = "Europa Universallis 4",
                    BackgroundPath = "/path/to/background2.jpg",
                    TrailerPath = "/path/to/trailer2.mp4",
                    PicturesPaths = new List<string> { "/GameImages/eu4.jpg", "/path/to/picture4.jpg" },
                    ReleaseDate = new DateOnly(2023, 3, 20),
                    SysReq = "Sample system requirements for Game 2.",
                    Price = 23.99m,
                    Size = "12.0m",
                    Description = "Sample description for Game 2."
                },
                new Game
                {
                    ID = 3,
                    Title = "Team Fortress 2",
                    BackgroundPath = "/path/to/background2.jpg",
                    TrailerPath = "/path/to/trailer2.mp4",
                    PicturesPaths = new List<string> { "/GameImages/tf2.jpg", "/path/to/picture4.jpg" },
                    ReleaseDate = new DateOnly(2023, 3, 20),
                    SysReq = "Sample system requirements for Game 2.",
                    Price = 0m,
                    Size = "12.0m",
                    Description = "Sample description for Game 2."
                },
                new Game
                {
                    ID = 4,
                    Title = "Stellaris",
                    BackgroundPath = "/path/to/background2.jpg",
                    TrailerPath = "/path/to/trailer2.mp4",
                    PicturesPaths = new List<string> { "/GameImages/stellaris.jpg", "/path/to/picture4.jpg" },
                    ReleaseDate = new DateOnly(2023, 3, 20),
                    SysReq = "Sample system requirements for Game 2.",
                    Price = 23.99m,
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
                    new GameDeveloper { GameID = 2, DeveloperID = 2 }
                );

        }
    }
}