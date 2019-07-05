using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Levantamento.Api.Migrations
{
    public partial class TipoLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Levantamento_LevantamentoRootId",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "LevantamentoRootId",
                table: "Log",
                newName: "LevantamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Log_LevantamentoRootId",
                table: "Log",
                newName: "IX_Log_LevantamentoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Log",
                type: "decimal(6,3)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                table: "Log",
                type: "decimal(12,9)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Log",
                type: "decimal(12,9)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOccurred",
                table: "Log",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Levantamento_LevantamentoId",
                table: "Log",
                column: "LevantamentoId",
                principalTable: "Levantamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Levantamento_LevantamentoId",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "LevantamentoId",
                table: "Log",
                newName: "LevantamentoRootId");

            migrationBuilder.RenameIndex(
                name: "IX_Log_LevantamentoId",
                table: "Log",
                newName: "IX_Log_LevantamentoRootId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Log",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                table: "Log",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "Log",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOccurred",
                table: "Log",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Levantamento_LevantamentoRootId",
                table: "Log",
                column: "LevantamentoRootId",
                principalTable: "Levantamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
