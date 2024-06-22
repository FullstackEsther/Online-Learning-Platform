using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ccaca1d1-2d2f-47ba-8ec3-21afc8e6b87f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6ca1901-433e-4408-94e3-668a3c76c086"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eebb32ff-cf5d-409d-99c8-411d9a7c0829"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName" },
                values: new object[,]
                {
                    { new Guid("39e1491f-6f64-41a7-984b-bc95ccf05862"), "Admin", new DateTime(2024, 6, 22, 9, 53, 39, 166, DateTimeKind.Local).AddTicks(8725), "Creates and owns a course ", null, null, "Instructor" },
                    { new Guid("9275f625-84a9-4a15-b3e6-89b6c303f1d9"), "Admin", new DateTime(2024, 6, 22, 9, 53, 39, 166, DateTimeKind.Local).AddTicks(8655), "Takes a course for better Understanding", null, null, "Student" },
                    { new Guid("f5b21e1b-119d-4008-8987-895f052b8346"), "Admin", new DateTime(2024, 6, 22, 9, 53, 39, 166, DateTimeKind.Local).AddTicks(8741), "Takes a course for better Understanding", null, null, "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("39e1491f-6f64-41a7-984b-bc95ccf05862"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9275f625-84a9-4a15-b3e6-89b6c303f1d9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f5b21e1b-119d-4008-8987-895f052b8346"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName" },
                values: new object[,]
                {
                    { new Guid("ccaca1d1-2d2f-47ba-8ec3-21afc8e6b87f"), "Admin", new DateTime(2024, 6, 20, 13, 39, 40, 654, DateTimeKind.Local).AddTicks(8509), "Creates and owns a course ", null, null, "Instructor" },
                    { new Guid("d6ca1901-433e-4408-94e3-668a3c76c086"), "Admin", new DateTime(2024, 6, 20, 13, 39, 40, 654, DateTimeKind.Local).AddTicks(8523), "Takes a course for better Understanding", null, null, "Admin" },
                    { new Guid("eebb32ff-cf5d-409d-99c8-411d9a7c0829"), "Admin", new DateTime(2024, 6, 20, 13, 39, 40, 654, DateTimeKind.Local).AddTicks(8447), "Takes a course for better Understanding", null, null, "Student" }
                });
        }
    }
}
