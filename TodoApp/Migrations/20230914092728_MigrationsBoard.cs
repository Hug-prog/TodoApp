using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "Todo",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_BoardId",
                table: "Todo",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Board_BoardId",
                table: "Todo",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Board_BoardId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_BoardId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Todo");
        }
    }
}
