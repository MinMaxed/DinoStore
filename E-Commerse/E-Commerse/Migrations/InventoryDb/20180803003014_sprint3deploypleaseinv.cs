using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations.InventoryDb
{
    public partial class sprint3deploypleaseinv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");
        }
    }
}
