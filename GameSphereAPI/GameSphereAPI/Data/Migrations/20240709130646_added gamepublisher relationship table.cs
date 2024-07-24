using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphereAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedgamepublisherrelationshiptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePublisher",
                schema: "gam");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                schema: "gam",
                table: "Publishers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GamePublishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "integer", nullable: false),
                    GameID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublishers", x => new { x.PublisherID, x.GameID });
                    table.ForeignKey(
                        name: "FK_GamePublishers_Games_PublisherID",
                        column: x => x.PublisherID,
                        principalSchema: "gam",
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublishers_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalSchema: "gam",
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 1,
                column: "GameID",
                value: null);

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 2,
                column: "GameID",
                value: null);

            migrationBuilder.UpdateData(
                schema: "gam",
                table: "Publishers",
                keyColumn: "ID",
                keyValue: 3,
                column: "GameID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_GameID",
                schema: "gam",
                table: "Publishers",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Games_GameID",
                schema: "gam",
                table: "Publishers",
                column: "GameID",
                principalSchema: "gam",
                principalTable: "Games",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Games_GameID",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropTable(
                name: "GamePublishers");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_GameID",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "GameID",
                schema: "gam",
                table: "Publishers");

            migrationBuilder.CreateTable(
                name: "GamePublisher",
                schema: "gam",
                columns: table => new
                {
                    PublishersID = table.Column<int>(type: "integer", nullable: false),
                    gamesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisher", x => new { x.PublishersID, x.gamesID });
                    table.ForeignKey(
                        name: "FK_GamePublisher_Games_gamesID",
                        column: x => x.gamesID,
                        principalSchema: "gam",
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisher_Publishers_PublishersID",
                        column: x => x.PublishersID,
                        principalSchema: "gam",
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisher_gamesID",
                schema: "gam",
                table: "GamePublisher",
                column: "gamesID");
        }
    }
}
