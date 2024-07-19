using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("23ca48a4-4ba0-4fad-a7f8-6468c62e17c1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("93370f1c-c237-4295-b548-94570b3b2e0b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d9c47bfd-13a9-4d15-b907-9667a365ec1e"));

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Enrollments");

            migrationBuilder.CreateTable(
                name: "UserProgresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserEmail = table.Column<string>(type: "longtext", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LessonId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName" },
                values: new object[,]
                {
                    { new Guid("22e3a5ce-2636-40d4-be22-a6afab99a90b"), "Admin", new DateTime(2024, 7, 19, 4, 12, 49, 380, DateTimeKind.Local).AddTicks(8743), "Takes a course for better Understanding", null, null, "Student" },
                    { new Guid("36013548-5c81-4cf2-8f71-b493216d3411"), "Admin", new DateTime(2024, 7, 19, 4, 12, 49, 380, DateTimeKind.Local).AddTicks(8783), "Creates and owns a course ", null, null, "Instructor" },
                    { new Guid("48a7e8bd-5059-40c5-8b64-ea6686978326"), "Admin", new DateTime(2024, 7, 19, 4, 12, 49, 380, DateTimeKind.Local).AddTicks(8789), "Takes a course for better Understanding", null, null, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_CourseId",
                table: "UserProgresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_LessonId",
                table: "UserProgresses",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_UserId",
                table: "UserProgresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgresses");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22e3a5ce-2636-40d4-be22-a6afab99a90b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("36013548-5c81-4cf2-8f71-b493216d3411"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("48a7e8bd-5059-40c5-8b64-ea6686978326"));

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Enrollments",
                type: "longtext",
                nullable: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName" },
                values: new object[,]
                {
                    { new Guid("23ca48a4-4ba0-4fad-a7f8-6468c62e17c1"), "Admin", new DateTime(2024, 7, 10, 13, 32, 8, 534, DateTimeKind.Local).AddTicks(219), "Takes a course for better Understanding", null, null, "Student" },
                    { new Guid("93370f1c-c237-4295-b548-94570b3b2e0b"), "Admin", new DateTime(2024, 7, 10, 13, 32, 8, 534, DateTimeKind.Local).AddTicks(266), "Creates and owns a course ", null, null, "Instructor" },
                    { new Guid("d9c47bfd-13a9-4d15-b907-9667a365ec1e"), "Admin", new DateTime(2024, 7, 10, 13, 32, 8, 534, DateTimeKind.Local).AddTicks(272), "Takes a course for better Understanding", null, null, "Admin" }
                });
        }
    }
}
