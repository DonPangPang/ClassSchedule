using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    ClassName = table.Column<string>(maxLength: 100, nullable: false),
                    Introduction = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    ClassId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    StudentName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(maxLength: 50, nullable: false),
                    WeekDay = table.Column<int>(nullable: false),
                    Lesson = table.Column<int>(nullable: false),
                    BeginWeek = table.Column<int>(nullable: false),
                    EndWeek = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(maxLength: 20, nullable: false),
                    SingleOrDouble = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("1b7b249e-658e-4ce5-a012-6277060e1a97"), "Class1", "This is Class 1." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("1bda4fd2-b11e-4934-8f40-3118a630b854"), "Class2", "This is Class 2." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("83b6fc4b-c619-478c-928c-ca5a9c2f728c"), "Class3", "This is Class 3." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "ClassId", "Password", "StudentId" },
                values: new object[] { "admin", new Guid("1b7b249e-658e-4ce5-a012-6277060e1a97"), "123456", new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "ClassId", "Password", "StudentId" },
                values: new object[] { "test1", new Guid("1bda4fd2-b11e-4934-8f40-3118a630b854"), "test1", new Guid("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "ClassId", "Password", "StudentId" },
                values: new object[] { "test2", new Guid("83b6fc4b-c619-478c-928c-ca5a9c2f728c"), "test2", new Guid("79b8da71-e41d-4210-b78b-89e415a65b19") });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
