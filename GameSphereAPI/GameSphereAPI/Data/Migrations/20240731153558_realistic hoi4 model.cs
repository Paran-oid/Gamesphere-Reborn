using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class realistichoi4model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
