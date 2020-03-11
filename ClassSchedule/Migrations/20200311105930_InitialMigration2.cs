using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassSchedule.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ClassId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "admin",
                column: "StudentId",
                value: new Guid("1ba17635-9c60-49f8-9fb4-bd8a1ed940fa"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test1",
                column: "StudentId",
                value: new Guid("38dd6584-af99-43d4-8040-d7f8ce8d1f78"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "test2",
                column: "StudentId",
                value: new Guid("a7006c05-5b20-4801-8131-6734d6fff00b"));
        }
    }
}
