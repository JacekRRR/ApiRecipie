using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipieRestAPI.Migrations
{
    public partial class Descripiotn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "connect",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictId = table.Column<long>(nullable: true),
                    IngridientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Directions = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    TimeForPrepare = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    KitchenFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOdError = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    LogDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingridients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Dishid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingridients", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingridients_dishes_Dishid",
                        column: x => x.Dishid,
                        principalTable: "dishes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingridients_Dishid",
                table: "ingridients",
                column: "Dishid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "connect");

            migrationBuilder.DropTable(
                name: "ingridients");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "dishes");
        }
    }
}
