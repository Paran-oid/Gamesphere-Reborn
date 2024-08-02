using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class newpicturesforHOI4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "faf115e3-20c5-4d0a-a1a1-d0788e67db21", "6117e876-0002-41c9-9580-b2efb2f6409c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70ce729b-ad35-4bbf-98e1-3105a91ec3f2", "a79e9239-4103-469a-bc0d-bba8a1f9b12f" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                column: "PicturesPaths",
                value: new List<string> { "/Games_Media/hoi4/Images/hoi4.jpg", "/Games_Media/hoi4/Images/picture2.jpg" });

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
