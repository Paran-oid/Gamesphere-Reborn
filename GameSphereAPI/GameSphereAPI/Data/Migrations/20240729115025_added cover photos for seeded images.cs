using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedcoverphotosforseededimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9d2f3b-ec85-44e8-b8ea-9a947bf2c9e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b821f49f-758e-4764-b907-53747926104d", "0e06f444-eb35-40e0-bc49-6cdfdf7e9083" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c2b0a4-0d8a-453f-92b6-897bd9d21f9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72084c71-e724-4eb2-aa76-f5c1027626b7", "fd2fa932-8d3a-4af1-9089-a9784d0e3ef1" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                column: "PicturesPaths",
                value: new List<string> { "/GameImages/stellaris.jpg", "/path/to/picture2.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                column: "PicturesPaths",
                value: new List<string> { "/GameImages/hoi4.jpg", "/path/to/picture4.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "PicturesPaths",
                value: new List<string> { "/path/to/picture1.jpg", "/path/to/picture2.jpg" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                column: "PicturesPaths",
                value: new List<string> { "/path/to/picture3.jpg", "/path/to/picture4.jpg" });
        }
    }
}
