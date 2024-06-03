using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Modules_ModuleId1",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ModuleId1",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ModuleId1",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "ModuleId1",
                table: "Quizzes",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ModuleId1",
                table: "Quizzes",
                column: "ModuleId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Modules_ModuleId1",
                table: "Quizzes",
                column: "ModuleId1",
                principalTable: "Modules",
                principalColumn: "Id");
        }
    }
}
