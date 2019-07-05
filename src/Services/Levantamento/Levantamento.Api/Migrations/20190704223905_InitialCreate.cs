using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Levantamento.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levantamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true)
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
                    Long = table.Column<decimal>(nullable: false),
                    Lat = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    DateOccurred = table.Column<DateTime>(nullable: false),
                    LevantamentoRootId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Levantamento_LevantamentoRootId",
                        column: x => x.LevantamentoRootId,
                        principalTable: "Levantamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_LevantamentoRootId",
                table: "Log",
                column: "LevantamentoRootId");
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
