using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class InitialMigration20200315 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "StudentName" },
                values: new object[] { new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"), new Guid("1b7b249e-658e-4ce5-a012-6277060e1a97"), "A Student" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "StudentName" },
                values: new object[] { new Guid("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a"), new Guid("1bda4fd2-b11e-4934-8f40-3118a630b854"), "B Student" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "StudentName" },
                values: new object[] { new Guid("79b8da71-e41d-4210-b78b-89e415a65b19"), new Guid("83b6fc4b-c619-478c-928c-ca5a9c2f728c"), "C Student" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "BeginWeek", "CourseName", "EndWeek", "Lesson", "SingleOrDouble", "StudentId", "TeacherName", "WeekDay" },
                values: new object[] { new Guid("0b1e1cb4-6ce1-498f-a944-32afd9217f5b"), 1, "Course A", 8, 1, 1, new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"), "Teacher A", 5 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "BeginWeek", "CourseName", "EndWeek", "Lesson", "SingleOrDouble", "StudentId", "TeacherName", "WeekDay" },
                values: new object[] { new Guid("16ae1317-603d-4e42-aa83-87a17cec2b00"), 1, "Course B", 8, 1, 1, new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"), "Teacher B", 5 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "BeginWeek", "CourseName", "EndWeek", "Lesson", "SingleOrDouble", "StudentId", "TeacherName", "WeekDay" },
                values: new object[] { new Guid("bf370188-1110-4794-85ae-19af49d1a2ac"), 1, "Course C", 8, 1, 1, new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"), "Teacher C", 5 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "BeginWeek", "CourseName", "EndWeek", "Lesson", "SingleOrDouble", "StudentId", "TeacherName", "WeekDay" },
                values: new object[] { new Guid("5334fc19-f39d-4b5e-87a2-125deb9483ea"), 1, "Course D", 8, 1, 1, new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"), "Teacher D", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("0b1e1cb4-6ce1-498f-a944-32afd9217f5b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("16ae1317-603d-4e42-aa83-87a17cec2b00"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("5334fc19-f39d-4b5e-87a2-125deb9483ea"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("bf370188-1110-4794-85ae-19af49d1a2ac"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("79b8da71-e41d-4210-b78b-89e415a65b19"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be"));
        }
    }
}
