using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    ParentCategory = table.Column<string>(type: "varchar(30)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoomName = table.Column<string>(type: "longtext", nullable: true),
                    IsGroupChat = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SenderUserName = table.Column<string>(type: "longtext", nullable: false),
                    ReceiverUserName = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Biography = table.Column<string>(type: "varchar(250)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    TrxRef = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Biography = table.Column<string>(type: "varchar(250)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    ResetPasswordCode = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ChatRoomId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SenderUserName = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    Timestamp = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: true),
                    TotalTime = table.Column<double>(type: "double", nullable: false),
                    InstructorName = table.Column<string>(type: "varchar(30)", nullable: false),
                    DisplayPicture = table.Column<string>(type: "varchar(255)", nullable: false),
                    WhatToLearn = table.Column<string>(type: "longtext", nullable: false),
                    IsVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CourseStatus = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    InstructorId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TotalScore = table.Column<double>(type: "double", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PaymentId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TotalTime = table.Column<double>(type: "double", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Topic = table.Column<string>(type: "varchar(50)", nullable: false),
                    File = table.Column<string>(type: "varchar(255)", nullable: false),
                    Article = table.Column<string>(type: "longtext", nullable: true),
                    ModuleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TotalMinutes = table.Column<double>(type: "double", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Duration = table.Column<double>(type: "double", nullable: false),
                    ModuleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    QuizId = table.Column<Guid>(type: "char(36)", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "varchar(255)", nullable: false),
                    Options = table.Column<string>(type: "json", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Score = table.Column<double>(type: "double", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    QuizId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsPassedTest = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QuestionAnswers = table.Column<string>(type: "json", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(60)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "ParentCategory" },
                values: new object[,]
                {
                    { new Guid("04a2830d-9811-4984-9a2a-5a5904f5d957"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 720, DateTimeKind.Local).AddTicks(5549), "Encompass the creative expression and application of visual and artistic skills", null, null, "Art and Design", null },
                    { new Guid("4b1d8bdb-5974-4321-a620-4389a7f1f617"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 720, DateTimeKind.Local).AddTicks(5603), "Encompasses the study of human culture, society, and the arts", null, null, "Humanities", null },
                    { new Guid("53cd1fd7-8794-4190-8e23-c338b1e050e2"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 720, DateTimeKind.Local).AddTicks(5561), "Stands for Science, Technology, Engineering, and Mathematics. It encompasses a wide range of fields related to scientific and technological advancements", null, null, "STEM", null },
                    { new Guid("58a8cf1d-96f4-4d56-b8a2-6da394fba413"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 720, DateTimeKind.Local).AddTicks(5592), "Encompasses the study of various aspects of running a business,Involves understanding how to plan, organize, lead, and control business operations", null, null, "Business and Management", null },
                    { new Guid("c3b288e3-26c9-4f46-8fba-d52a2686ad0b"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 720, DateTimeKind.Local).AddTicks(5493), "Encompasses activities aimed at improving one's skills, knowledge, and career prospects", null, null, "Profesional Development", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName" },
                values: new object[,]
                {
                    { new Guid("585b4c55-95f2-4a63-895a-bfa0b1731fc3"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 734, DateTimeKind.Local).AddTicks(9473), "Takes a course for better Understanding", null, null, "Student" },
                    { new Guid("95431a3c-63cf-480d-9350-7a8f92f15c4f"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 734, DateTimeKind.Local).AddTicks(9563), "Takes a course for better Understanding", null, null, "Admin" },
                    { new Guid("d11bfd10-d65f-45f6-8e68-d5157fb4e80c"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 734, DateTimeKind.Local).AddTicks(9530), "Creates and owns a course ", null, null, "Instructor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Password", "ResetPasswordCode", "Username" },
                values: new object[] { new Guid("e8374987-be9c-4099-91a6-a024754b7703"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 736, DateTimeKind.Local).AddTicks(5558), null, null, "Tolulope*1", 0, "otufaleesther@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("b9a5b636-31f2-4b83-abe8-2bdcaabf2783"), "Admin", new DateTime(2024, 8, 27, 7, 23, 44, 737, DateTimeKind.Local).AddTicks(7057), null, null, new Guid("95431a3c-63cf-480d-9350-7a8f92f15c4f"), new Guid("e8374987-be9c-4099-91a6-a024754b7703") });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_PaymentId",
                table: "Enrollments",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ModuleId",
                table: "Quizzes",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_QuizId",
                table: "Results",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "UserProgresses");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
