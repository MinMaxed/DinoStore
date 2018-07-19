using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations
{
    public partial class basketinv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Archaeopteryx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Archeopteryx");
        }
    }
}
