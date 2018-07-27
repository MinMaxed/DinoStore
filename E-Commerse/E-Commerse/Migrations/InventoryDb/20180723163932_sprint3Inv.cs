using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations.InventoryDb
{
    public partial class sprint3Inv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "\\Images\\Anklyosaurus.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "\\Images\\Ankylosaurus.jpg");
        }
    }
}
