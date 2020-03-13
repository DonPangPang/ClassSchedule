using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("10ef6ade-875f-421f-a405-e40decd2651c"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("25648edb-ef72-42d2-bb66-11b7a4e9a17b"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("4c4b5936-6842-4bc2-a050-f633510fa7de"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("9433d145-5f42-4e4a-9ba4-0748fff8e6e6"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("cb38a446-b030-4ff9-94b6-d4cc7803a84e"));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "admin",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("1b7b249e-658e-4ce5-a012-6277060e1a97"), new Guid("b4aab9f4-c743-4fc5-a09e-aa172fc318be") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test1",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("1bda4fd2-b11e-4934-8f40-3118a630b854"), new Guid("57700e3b-ea69-48a4-90cf-6e5bfc9bec6a") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test2",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("83b6fc4b-c619-478c-928c-ca5a9c2f728c"), new Guid("79b8da71-e41d-4210-b78b-89e415a65b19") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("1b7b249e-658e-4ce5-a012-6277060e1a97"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("1bda4fd2-b11e-4934-8f40-3118a630b854"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("83b6fc4b-c619-478c-928c-ca5a9c2f728c"));

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("9433d145-5f42-4e4a-9ba4-0748fff8e6e6"), "Class1", "This is Class 1." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("4c4b5936-6842-4bc2-a050-f633510fa7de"), "Class2", "This is Class 2." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("10ef6ade-875f-421f-a405-e40decd2651c"), "Class3", "This is Class 3." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("25648edb-ef72-42d2-bb66-11b7a4e9a17b"), "Class4", "This is Class 4." });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Introduction" },
                values: new object[] { new Guid("cb38a446-b030-4ff9-94b6-d4cc7803a84e"), "Class5", "This is Class 5." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "admin",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("b8395db5-d633-4d0d-beb5-62e8446f1d8b"), new Guid("fe4e3aeb-8772-42f3-acd7-81303a7522d5") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test1",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("a0994120-8d5e-4db5-befa-039793f2cd20"), new Guid("7c52bd70-ab30-48f1-860d-6df711b71fb8") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test2",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("6fce4416-93ff-47ff-b274-8581f3823979"), new Guid("5ae0ff83-5b80-46f1-975a-f7256ead77dc") });
        }
    }
}
