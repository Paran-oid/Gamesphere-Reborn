using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class changefromdecimaltostringforgamesize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Size",
                schema: "gam",
                table: "Games",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "PicturesPaths", "Size" },
                values: new object[] { new List<string> { "/path/to/picture1.jpg", "/path/to/picture2.jpg" }, "15.5m" });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PicturesPaths", "Size" },
                values: new object[] { new List<string> { "/path/to/picture3.jpg", "/path/to/picture4.jpg" }, "12.0m" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                schema: "gam",
                table: "Games",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "PicturesPaths", "Size" },
                values: new object[] { new List<string> { "/path/to/picture1.jpg", "/path/to/picture2.jpg" }, 15.5m });

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Games",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PicturesPaths", "Size" },
                values: new object[] { new List<string> { "/path/to/picture3.jpg", "/path/to/picture4.jpg" }, 12.0m });
        }
    }
}
