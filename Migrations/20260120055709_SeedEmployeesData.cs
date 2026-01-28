using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPractika.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DateOfEmployment", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 1, "18.09.2007", "20.11.2026", "Develop", "Ilya", "Gribanov", 2000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
