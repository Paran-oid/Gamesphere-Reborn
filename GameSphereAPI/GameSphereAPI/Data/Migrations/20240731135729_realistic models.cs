using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class realisticmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15d6f8ec-1ddf-42dd-bab6-3701ea6593be", "06d575c5-e7a3-471e-9dba-ae58dcb55dbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f49bc40-c334-434c-ad42-51db38040098", "19fa5b1b-3d84-4b06-8b5d-396f1656a324" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/Games_Media/hoi4/Images/background1.jpg", "Hearts of Iron IV lets you take command of any nation in World War II; the most engaging conflict in world history.", new List<string> { "/Games_Media/hoi4/Images/hoi4.jpg", "/Games_Media/hoi4/Images/picture2.jpg" }, 39.99m, new DateOnly(2016, 6, 6), "2.5GB", "OS: Windows 10, Processor: Intel Core i5, Memory: 4 GB RAM, Graphics: ATI Radeon HD 6950, Storage: 2 GB available space", "/Games_Media/hoi4/Videos/trailer1.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "Title", "TrailerPath" },
                values: new object[] { "/Games_Media/eu4/Images/background2.jpg", "Europa Universalis IV gives you control of a nation to guide through the years in order to create a dominant global empire.", new List<string> { "/Games_Media/eu4/Images/eu4.jpg", "/Games_Media/eu4/Images/picture4.jpg" }, 39.99m, new DateOnly(2013, 8, 13), "1.5GB", "OS: Windows 7, Processor: Intel Pentium IV, Memory: 2 GB RAM, Graphics: NVIDIA GeForce 8800, Storage: 2 GB available space", "Europa Universalis IV", "/Games_Media/eu4/Videos/trailer2.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/Games_Media/tf2/Images/background2.jpg", "Team Fortress 2 is a team-based multiplayer first-person shooter game developed and published by Valve Corporation.", new List<string> { "/Games_Media/tf2/Images/tf2.jpg", "/Games_Media/tf2/Images/picture4.jpg" }, new DateOnly(2007, 10, 10), "15GB", "OS: Windows 7, Processor: 1.7 GHz Processor, Memory: 512 MB RAM, Graphics: DirectX 8.1 level Graphics Card, Storage: 15 GB available space", "/Games_Media/tf2/Videos/trailer2.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/Games_Media/stellaris/Images/background2.jpg", "Stellaris is a real-time grand strategy game set in space, beginning in the year 2200.", new List<string> { "/Games_Media/stellaris/Images/stellaris.jpg", "/Games_Media/stellaris/Images/picture4.jpg" }, 39.99m, new DateOnly(2016, 5, 9), "10GB", "OS: Windows 7 64-bit, Processor: Intel iCore i3-530, Memory: 4 GB RAM, Graphics: NVIDIA GeForce GTX 460, Storage: 10 GB available space", "/Games_Media/stellaris/Videos/trailer2.mp4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1575f79c-e5b2-40c3-a9bd-a893ef69e13a", "1757a6dd-b0bf-4b8b-a932-aa46309e5f07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a0c16800-4b0d-4939-8392-a6b86ae81b56", "24ed1561-3077-48d9-99fd-6efedf6e409d" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/path/to/background1.jpg", "Sample description for Game 1.", new List<string> { "/GameImages/hoi4.jpg", "/path/to/picture2.jpg" }, 29.99m, new DateOnly(2023, 1, 15), "15.5m", "Sample system requirements for Game 1.", "/path/to/trailer1.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "Title", "TrailerPath" },
                values: new object[] { "/path/to/background2.jpg", "Sample description for Game 2.", new List<string> { "/GameImages/eu4.jpg", "/path/to/picture4.jpg" }, 23.99m, new DateOnly(2023, 3, 20), "12.0m", "Sample system requirements for Game 2.", "Europa Universallis 4", "/path/to/trailer2.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/path/to/background2.jpg", "Sample description for Game 2.", new List<string> { "/GameImages/tf2.jpg", "/path/to/picture4.jpg" }, new DateOnly(2023, 3, 20), "12.0m", "Sample system requirements for Game 2.", "/path/to/trailer2.mp4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "TrailerPath" },
                values: new object[] { "/path/to/background2.jpg", "Sample description for Game 2.", new List<string> { "/GameImages/stellaris.jpg", "/path/to/picture4.jpg" }, 23.99m, new DateOnly(2023, 3, 20), "12.0m", "Sample system requirements for Game 2.", "/path/to/trailer2.mp4" });
        }
    }
}
