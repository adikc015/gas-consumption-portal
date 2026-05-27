using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login_page.Migrations
{
    /// <inheritdoc />
    public partial class AddGasConsumptionRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasConsumptionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UnitsConsumed = table.Column<decimal>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasConsumptionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasConsumptionRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasConsumptionRecords_UserId",
                table: "GasConsumptionRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasConsumptionRecords");
        }
    }
}
