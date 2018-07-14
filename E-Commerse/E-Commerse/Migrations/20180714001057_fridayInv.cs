using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations
{
    public partial class fridayInv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "\\Images\\Archaeopteryx.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "\\Images\\Archeopteryx.jpg");
        }
    }
}
