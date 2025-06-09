using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium_s31080.Migrations
{
    /// <inheritdoc />
    public partial class tabelki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Credits = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Teacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.Student_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Credits", "Teacher", "Title" },
                values: new object[,]
                {
                    { 101, "6 ECTS", "dr Kowalski", "Wprowadzenie do Algorytmów" },
                    { 102, "5 ECTS", "mgr Nowicka", "Bazy Danych" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "anna.nowak@example.edu", "Anna", "Nowak" },
                    { 2, "tomasz.w@example.edu", "Tomasz", "Wiśniewski" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "Course_Id", "Student_Id", "EnrollmentDate" },
                values: new object[,]
                {
                    { 101, 1, new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 2, new DateTime(2024, 10, 2, 9, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Course_Id",
                table: "Enrollment",
                column: "Course_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
