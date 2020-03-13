using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("01aec6ed-53a9-4281-8864-a3456b7443ad"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("181be1ec-eee9-41c0-8957-383c8e18ec38"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("8dec0933-6842-497b-a04e-c20ea7a86707"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("b4fef31c-9ab7-438c-ae83-68d9c03a241f"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: new Guid("d0a8c12f-ad9c-41ee-b537-5acbeac653f1"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Introduction", "Name" },
                values: new object[] { new Guid("8dec0933-6842-497b-a04e-c20ea7a86707"), "This is Class 1.", "Class1" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Introduction", "Name" },
                values: new object[] { new Guid("b4fef31c-9ab7-438c-ae83-68d9c03a241f"), "This is Class 1.", "Class1" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Introduction", "Name" },
                values: new object[] { new Guid("d0a8c12f-ad9c-41ee-b537-5acbeac653f1"), "This is Class 1.", "Class1" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Introduction", "Name" },
                values: new object[] { new Guid("01aec6ed-53a9-4281-8864-a3456b7443ad"), "This is Class 1.", "Class1" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Introduction", "Name" },
                values: new object[] { new Guid("181be1ec-eee9-41c0-8957-383c8e18ec38"), "This is Class 1.", "Class1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "admin",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("e4d182b4-bde0-4c59-95e0-9522c05b4a08"), new Guid("de70865f-6cb9-4dd2-8d88-d81324824131") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test1",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("05082016-cdf9-4f29-af4a-e8da6fa6452d"), new Guid("37c3cb75-9dc8-4b41-b472-282347f6433b") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test2",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[] { new Guid("41ef3e75-63e0-485e-8c8a-c7d420a2c8e6"), new Guid("0738175f-022a-4d72-97f4-4fc6e1b58ac5") });
        }
    }
}
