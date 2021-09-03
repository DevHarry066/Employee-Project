using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeWebAPI.Migrations
{
    public partial class RemovedProductPropertyFromDealOfdayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealOfDays_Products_ProductId",
                table: "DealOfDays");

            migrationBuilder.DropIndex(
                name: "IX_DealOfDays_ProductId",
                table: "DealOfDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DealOfDays_ProductId",
                table: "DealOfDays",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealOfDays_Products_ProductId",
                table: "DealOfDays",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
