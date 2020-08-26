using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class SeedingEmployeeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "AvatarPath", "Department", "Email", "FullName" },
                values: new object[] { 1, "~/images/mangtae.jpg", 0, "anhkhoa@codegym.vn", "Anh Khoa" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "AvatarPath", "Department", "Email", "FullName" },
                values: new object[] { 2, "~/images/mangtae.jpg", 1, "ynhi@codegym.vn", "Ý Nhi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
