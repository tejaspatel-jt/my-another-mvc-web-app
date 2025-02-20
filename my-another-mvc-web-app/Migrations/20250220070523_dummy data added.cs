using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace my_another_mvc_web_app.Migrations
{
    /// <inheritdoc />
    public partial class dummydataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "EnrollmentDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tejas" },
                    { 2, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rahul" },
                    { 3, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rohit" },
                    { 4, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raju" },
                    { 5, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ravi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }
    }
}
