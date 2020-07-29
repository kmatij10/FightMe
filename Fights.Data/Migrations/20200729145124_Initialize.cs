using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fights.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Swipes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    User1Id = table.Column<long>(nullable: false),
                    User2Id = table.Column<long>(nullable: false),
                    IsSuperSwipe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    User1Id = table.Column<long>(nullable: false),
                    User2Id = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fights_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    FightId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Zagreb" },
                    { 2L, "Krk" }
                });

            migrationBuilder.InsertData(
                table: "Swipes",
                columns: new[] { "Id", "CreatedAt", "IsSuperSwipe", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 7, 29, 16, 51, 24, 496, DateTimeKind.Local).AddTicks(2191), 1, 1L, 2L },
                    { 2L, new DateTime(2020, 7, 29, 16, 51, 24, 496, DateTimeKind.Local).AddTicks(2873), 0, 4L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Fights",
                columns: new[] { "Id", "Address", "CityId", "User1Id", "User2Id" },
                values: new object[] { 1L, "Vukovarska 238", 1L, 1L, 2L });

            migrationBuilder.InsertData(
                table: "Fights",
                columns: new[] { "Id", "Address", "CityId", "User1Id", "User2Id" },
                values: new object[] { 2L, "Ohridska 23", 2L, 4L, 5L });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "CreatedAt", "FightId", "UserId" },
                values: new object[] { 1L, 22.4m, new DateTime(2020, 7, 29, 16, 51, 24, 493, DateTimeKind.Local).AddTicks(1154), 1L, 1L });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "CreatedAt", "FightId", "UserId" },
                values: new object[] { 2L, 12.4m, new DateTime(2020, 7, 29, 16, 51, 24, 496, DateTimeKind.Local).AddTicks(565), 1L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_FightId",
                table: "Donations",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_CityId",
                table: "Fights",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Swipes");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
