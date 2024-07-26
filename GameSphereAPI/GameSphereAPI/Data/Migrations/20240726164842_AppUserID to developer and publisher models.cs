using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class AppUserIDtodeveloperandpublishermodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                schema: "gam",
                table: "Reviews");

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
                name: "UserID",
                schema: "gam",
                table: "Reviews",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserID",
                schema: "gam",
                table: "Reviews",
                newName: "IX_Reviews_AppUserID");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                schema: "gam",
                table: "Publishers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "gam",
                table: "Publishers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                schema: "gam",
                table: "News",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "gam",
                table: "News",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                schema: "gam",
                table: "Developers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "gam",
                table: "Developers",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_AppUserId",
                schema: "gam",
                table: "Publishers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_AppUserId",
                schema: "gam",
                table: "News",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_AppUserId",
                schema: "gam",
                table: "Developers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Developers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AppUserId",
                schema: "gam",
                table: "News",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Reviews",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AppUserId",
                schema: "gam",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_AspNetUsers_AppUserId",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserID",
                schema: "gam",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_AppUserId",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_News_AppUserId",
                schema: "gam",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Developers_AppUserId",
                schema: "gam",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                schema: "gam",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "gam",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "gam",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                schema: "gam",
                table: "Reviews",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AppUserID",
                schema: "gam",
                table: "Reviews",
                newName: "IX_Reviews_UserID");

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
                columns: new[] { "ID", "GameID", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, null, "Publisher X", 2.1m },
                    { 2, null, "Publisher Y", 3.8m },
                    { 3, null, "Publisher Z", 4.2m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                schema: "gam",
                table: "Reviews",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
