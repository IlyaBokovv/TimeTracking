using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("20da4841-4a17-42e6-bd69-6a7025160082"), "testmail@mail.ru", "Elon", "Musk", "Viktorovich" },
                    { new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"), "testmail@yandex.ru", "Vladimir", "Lenin", "Ilyich" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Date", "Description", "UserId", "WorkedHours" },
                values: new object[,]
                {
                    { new Guid("33502293-c17a-4ef8-ac61-75c62ecde637"), new DateOnly(2023, 9, 15), "Extra hours", new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"), 3 },
                    { new Guid("b541ca9d-7257-47be-b812-5bbdbb588216"), new DateOnly(2023, 9, 15), "Regular job", new Guid("20da4841-4a17-42e6-bd69-6a7025160082"), 8 },
                    { new Guid("db0abfe7-bf93-41fa-a537-396e76faaced"), new DateOnly(2023, 9, 15), "Regular job", new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"), 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("33502293-c17a-4ef8-ac61-75c62ecde637"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("b541ca9d-7257-47be-b812-5bbdbb588216"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("db0abfe7-bf93-41fa-a537-396e76faaced"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("20da4841-4a17-42e6-bd69-6a7025160082"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
