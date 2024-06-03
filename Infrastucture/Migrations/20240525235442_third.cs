using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId1",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseId1",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_CourseId1",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CourseId1",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "SerializedResponse",
                table: "Results",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerializedResponse",
                table: "Results");

            migrationBuilder.AddColumn<string>(
                name: "CourseId1",
                table: "Modules",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseId1",
                table: "Enrollments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Courses",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId1",
                table: "Modules",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId1",
                table: "Enrollments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId1",
                table: "Courses",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId1",
                table: "Courses",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId1",
                table: "Enrollments",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseId1",
                table: "Modules",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
