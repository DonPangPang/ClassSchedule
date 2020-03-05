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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
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
                table: "Users",
                columns: new[] { "UserName", "Password", "StudentId" },
                values: new object[] { "admin", "123456", new Guid("1ba17635-9c60-49f8-9fb4-bd8a1ed940fa") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Password", "StudentId" },
                values: new object[] { "test1", "test1", new Guid("38dd6584-af99-43d4-8040-d7f8ce8d1f78") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Password", "StudentId" },
                values: new object[] { "test2", "test2", new Guid("a7006c05-5b20-4801-8131-6734d6fff00b") });

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
