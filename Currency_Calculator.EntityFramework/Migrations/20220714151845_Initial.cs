using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Currency_Calculator.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyRatesAndEffectiveDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRatesAndEffectiveDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    ExchangeRate = table.Column<double>(type: "REAL", nullable: false),
                    CurrencyRatesAndEffectiveDateDtoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyDto_CurrencyRatesAndEffectiveDate_CurrencyRatesAndEffectiveDateDtoId",
                        column: x => x.CurrencyRatesAndEffectiveDateDtoId,
                        principalTable: "CurrencyRatesAndEffectiveDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyDto_CurrencyRatesAndEffectiveDateDtoId",
                table: "CurrencyDto",
                column: "CurrencyRatesAndEffectiveDateDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyDto");

            migrationBuilder.DropTable(
                name: "CurrencyRatesAndEffectiveDate");
        }
    }
}
