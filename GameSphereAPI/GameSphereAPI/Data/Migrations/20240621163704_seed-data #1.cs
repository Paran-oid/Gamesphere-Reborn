using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeddata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "AppRole", "Admin", "ADMIN" },
                    { "2", null, "AppRole", "Publisher", "PUBLISHER" },
                    { "3", null, "AppRole", "Developer", "DEVELOPER" },
                    { "4", null, "AppRole", "User", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Developers",
                columns: new[] { "ID", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Developer X", 4.2m },
                    { 2, "Developer Y", 4.1m },
                    { 3, "Developer Z", 4.3m }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Games",
                columns: new[] { "ID", "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "Title", "TrailerPath" },
                values: new object[,]
                {
                    { 1, "/path/to/background1.jpg", "Sample description for Game 1.", new[] { "/path/to/picture1.jpg", "/path/to/picture2.jpg" }, 49.99m, new DateOnly(2023, 1, 15), 15.5m, "Sample system requirements for Game 1.", "Sample Game 1", "/path/to/trailer1.mp4" },
                    { 2, "/path/to/background2.jpg", "Sample description for Game 2.", new[] { "/path/to/picture3.jpg", "/path/to/picture4.jpg" }, 39.99m, new DateOnly(2023, 3, 20), 12.0m, "Sample system requirements for Game 2.", "Sample Game 2", "/path/to/trailer2.mp4" }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Genres",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Role-playing" }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Languages",
                columns: new[] { "ID", "GameID", "Name" },
                values: new object[,]
                {
                    { 1, null, "English" },
                    { 2, null, "French" },
                    { 3, null, "Spanish" }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Publishers",
                columns: new[] { "ID", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Publisher X", 2.1m },
                    { 2, "Publisher Y", 3.8m },
                    { 3, "Publisher Z", 4.2m }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Tags",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "RPG" }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "GameDevelopers",
                columns: new[] { "DeveloperID", "GameID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "GameLanguages",
                columns: new[] { "GameID", "LanguageID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "GameTags",
                columns: new[] { "GameID", "TagID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameDevelopers",
                keyColumns: new[] { "DeveloperID", "GameID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameDevelopers",
                keyColumns: new[] { "DeveloperID", "GameID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameDevelopers",
                keyColumns: new[] { "DeveloperID", "GameID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameDevelopers",
                keyColumns: new[] { "DeveloperID", "GameID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameGenres",
                keyColumns: new[] { "GameID", "GenreID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameGenres",
                keyColumns: new[] { "GameID", "GenreID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameGenres",
                keyColumns: new[] { "GameID", "GenreID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameGenres",
                keyColumns: new[] { "GameID", "GenreID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameLanguages",
                keyColumns: new[] { "GameID", "LanguageID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameLanguages",
                keyColumns: new[] { "GameID", "LanguageID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameLanguages",
                keyColumns: new[] { "GameID", "LanguageID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameLanguages",
                keyColumns: new[] { "GameID", "LanguageID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameTags",
                keyColumns: new[] { "GameID", "TagID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameTags",
                keyColumns: new[] { "GameID", "TagID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameTags",
                keyColumns: new[] { "GameID", "TagID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "GameTags",
                keyColumns: new[] { "GameID", "TagID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Developers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Developers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Developers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Genres",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Genres",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Genres",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Languages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Languages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Languages",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
