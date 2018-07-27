using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations.InventoryDb
{
    public partial class nobasketitemlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketID",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Products_ProductID",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_BasketID",
                table: "BasketItem");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_ProductID",
                table: "BasketItems",
                newName: "IX_BasketItems_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "BasketID",
                table: "BasketItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItem",
                newName: "IX_BasketItem_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "BasketID",
                table: "BasketItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketID",
                table: "BasketItem",
                column: "BasketID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketID",
                table: "BasketItem",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Products_ProductID",
                table: "BasketItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
