using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class moretestmediaforhoi4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc8a52b9-7901-425a-91d9-0936e3667e92", "8434e8c8-d0d0-4eab-9df6-ff980f29f17e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "807e6ab7-bf4b-4843-8562-c1be315604ea", "f0f8e576-cdbf-4a11-a7b4-ea2afb25d04a" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/hoi4/Images/hoi4.jpg", "/Games_Media/hoi4/Images/picture2.jpg", "/Games_Media/hoi4/Images/picture3.jpg", "/Games_Media/hoi4/Images/picture4.jpg", "/Games_Media/hoi4/Images/picture5.jpg", "/Games_Media/hoi4/Images/picture6.jpg", "/Games_Media/hoi4/Images/picture7.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/eu4/Images/eu4.jpg", "/Games_Media/eu4/Images/picture4.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 3,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/tf2/Images/tf2.jpg", "/Games_Media/tf2/Images/picture4.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 4,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/stellaris/Images/stellaris.jpg", "/Games_Media/stellaris/Images/picture4.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "40c57e1a-fb72-4a6a-9da5-ce74d5624c61", "0a655098-ec3b-4920-9325-7824f78fce25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "110e2552-9477-4966-ab11-db3c3904f1df", "b50c6e6a-502e-4778-abcb-41a84c65337a" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/hoi4/Images/hoi4.jpg", "/Games_Media/hoi4/Images/picture2.jpg", "/Games_Media/hoi4/Images/picture3.jpg", "/Games_Media/hoi4/Images/picture4.jpg", "/Games_Media/hoi4/Images/picture5.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/eu4/Images/eu4.jpg", "/Games_Media/eu4/Images/picture4.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 3,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/tf2/Images/tf2.jpg", "/Games_Media/tf2/Images/picture4.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 4,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/stellaris/Images/stellaris.jpg", "/Games_Media/stellaris/Images/picture4.jpg" });
        }
    }
}
