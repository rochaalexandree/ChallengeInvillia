using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeInvillia.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsOnLoan = table.Column<bool>(nullable: false),
                    FriendId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => new { x.Id, x.Name });
                    table.ForeignKey(
                        name: "FK_Games_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameRenteds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    GameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRenteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRenteds_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameRenteds_Games_GameId_GameName",
                        columns: x => new { x.GameId, x.GameName },
                        principalTable: "Games",
                        principalColumns: new[] { "Id", "Name" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRenteds_FriendId",
                table: "GameRenteds",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRenteds_GameId_GameName",
                table: "GameRenteds",
                columns: new[] { "GameId", "GameName" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_FriendId",
                table: "Games",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRenteds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
