using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations.InventoryDb
{
    public partial class productid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "BasketItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "BasketItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
