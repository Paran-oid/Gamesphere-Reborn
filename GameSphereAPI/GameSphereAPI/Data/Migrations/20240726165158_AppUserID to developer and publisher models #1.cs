using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class AppUserIDtodeveloperandpublishermodels1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                schema: "gam",
                table: "Publishers",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Publishers_AppUserId",
                schema: "gam",
                table: "Publishers",
                newName: "IX_Publishers_AppUserID");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                schema: "gam",
                table: "Developers",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_AppUserId",
                schema: "gam",
                table: "Developers",
                newName: "IX_Developers_AppUserID");

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Developers",
                columns: new[] { "ID", "AppUserID", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", "Developer X", 4.2m },
                    { 2, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", "Developer Y", 4.1m },
                    { 3, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", "Developer Z", 4.3m }
                });

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

            migrationBuilder.InsertData(
                schema: "gam",
                table: "Publishers",
                columns: new[] { "ID", "AppUserID", "GameID", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", null, "Publisher X", 2.1m },
                    { 2, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", null, "Publisher Y", 3.8m },
                    { 3, "0b8cff9b-07a7-40ba-973a-ccb0cd04927e", null, "Publisher Z", 4.2m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Developers",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Publishers",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Publishers");

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

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Publishers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Publishers_AppUserID",
                schema: "gam",
                table: "Publishers",
                newName: "IX_Publishers_AppUserId");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Developers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_AppUserID",
                schema: "gam",
                table: "Developers",
                newName: "IX_Developers_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                schema: "gam",
                table: "Publishers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                schema: "gam",
                table: "Developers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Developers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Publishers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
