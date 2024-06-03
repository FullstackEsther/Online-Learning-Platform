using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Results",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_QuizId",
                table: "Results",
                newName: "IX_Results_ModuleId");

            migrationBuilder.RenameColumn(
                name: "numberOfModules",
                table: "Courses",
                newName: "NumberOfModules");

            migrationBuilder.AddColumn<Guid>(
                name: "ModuleId1",
                table: "Quizzes",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseId1",
                table: "Modules",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TotalTime",
                table: "Courses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ModuleId1",
                table: "Quizzes",
                column: "ModuleId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId1",
                table: "Modules",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseId1",
                table: "Modules",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Modules_ModuleId1",
                table: "Quizzes",
                column: "ModuleId1",
                principalTable: "Modules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Modules_ModuleId",
                table: "Results",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseId1",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Modules_ModuleId1",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Modules_ModuleId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ModuleId1",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Modules_CourseId1",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleId1",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Results",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ModuleId",
                table: "Results",
                newName: "IX_Results_QuizId");

            migrationBuilder.RenameColumn(
                name: "NumberOfModules",
                table: "Courses",
                newName: "numberOfModules");

            migrationBuilder.AlterColumn<double>(
                name: "TotalTime",
                table: "Courses",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
