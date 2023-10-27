using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentDate",
                table: "Reports",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reports",
                newName: "CurrentDate");
        }
    }
}
