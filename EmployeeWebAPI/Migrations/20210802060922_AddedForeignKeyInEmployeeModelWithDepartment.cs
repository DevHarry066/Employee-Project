using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeWebAPI.Migrations
{
    public partial class AddedForeignKeyInEmployeeModelWithDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employeess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeess_DepartmentId",
                table: "Employeess",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeess_Department_DepartmentId",
                table: "Employeess",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeess_Department_DepartmentId",
                table: "Employeess");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employeess_DepartmentId",
                table: "Employeess");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employeess");
        }
    }
}
