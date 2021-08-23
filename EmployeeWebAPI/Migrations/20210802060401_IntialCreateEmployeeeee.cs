using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeWebAPI.Migrations
{
    public partial class IntialCreateEmployeeeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employeess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employeess",
                table: "Employeess",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employeess",
                table: "Employeess");

            migrationBuilder.RenameTable(
                name: "Employeess",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");
        }
    }
}
