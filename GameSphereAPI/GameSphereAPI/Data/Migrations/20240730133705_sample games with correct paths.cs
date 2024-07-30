using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class samplegameswithcorrectpaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "PicturesPaths", "Price", "Title" },
                values: new object[] { new List<string> { "/GameImages/hoi4.jpg", "/path/to/picture2.jpg" }, 29.99m, "Hearts of Iron 4" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PicturesPaths", "Price", "Title" },
                values: new object[] { new List<string> { "/GameImages/eu4.jpg", "/path/to/picture4.jpg" }, 23.99m, "Europa Universallis 4" });

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Games",
                columns: new[] { "ID", "BackgroundPath", "Description", "PicturesPaths", "Price", "ReleaseDate", "Size", "SysReq", "Title", "TrailerPath" },
                values: new object[,]
                {
                    { 3, "/path/to/background2.jpg", "Sample description for Game 2.", new List<string> { "/GameImages/tf2.jpg", "/path/to/picture4.jpg" }, 0m, new DateOnly(2023, 3, 20), "12.0m", "Sample system requirements for Game 2.", "Team Fortress 2", "/path/to/trailer2.mp4" },
                    { 4, "/path/to/background2.jpg", "Sample description for Game 2.", new List<string> { "/GameImages/stellaris.jpg", "/path/to/picture4.jpg" }, 23.99m, new DateOnly(2023, 3, 20), "12.0m", "Sample system requirements for Game 2.", "Stellaris", "/path/to/trailer2.mp4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e46e5979-afb3-4084-a60b-0dd6db031d72", "c6b0b50f-b938-453b-82a6-da1cad3531b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d094706-4821-4c3d-96d4-66ed19292009", "378213c4-b50a-434a-b551-8edbe1eabaf8" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "PicturesPaths", "Price", "Title" },
                values: new object[] { new List<string> { "/path/to/picture1.jpg", "/path/to/picture2.jpg" }, 49.99m, "Sample Game 1" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PicturesPaths", "Price", "Title" },
                values: new object[] { new List<string> { "/path/to/picture3.jpg", "/path/to/picture4.jpg" }, 39.99m, "Sample Game 2" });
        }
    }
}
