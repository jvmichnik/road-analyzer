using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Levantamento.Api.Infrastructure.Migrations.Levantamento
{
    public partial class InitialLevantamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levantamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime", nullable: false),
                    End = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levantamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Long = table.Column<decimal>(type: "decimal(12,9)", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(12,9)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "datetime", nullable: false),
                    LevantamentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Levantamento_LevantamentoId",
                        column: x => x.LevantamentoId,
                        principalTable: "Levantamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_LevantamentoId",
                table: "Log",
                column: "LevantamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Levantamento");
        }
    }
}
