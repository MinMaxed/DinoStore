using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations.InventoryDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true),
                    BasketID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasketItem_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "King of the Dinos", "\\Images\\Tyrannosaurus.jpg", "Tyranosaurus", 199.99m, "00001" },
                    { 2, "3 times the power of a Rhinocerous", "\\Images\\Triceratops.jpg", "Triceratops", 199.99m, "00002" },
                    { 3, "Soaring the skies", "\\Images\\Pteradactyl.jpg", "Pteradactyl", 199.99m, "00003" },
                    { 4, "Grandpa of the giraffe", "\\Images\\Brachiosaurus.jpg", "Brachiosaurus", 199.99m, "00004" },
                    { 5, "The walking tank of the Cretaceous", "\\Images\\Ankylosaurus.jpg", "Ankylosaurus", 199.99m, "00005" },
                    { 6, "Pack hunting terror of the Creatceous", "\\Images\\Velociraptor.jpg", "Velociraptor", 199.99m, "00006" },
                    { 7, "The missing link", "\\Images\\Archaeopteryx.jpg", "Archaeopteryx", 199.99m, "00007" },
                    { 8, "Jurassic terror", "\\Images\\Allosaurus.jpg", "Allosaurus", 199.99m, "00008" },
                    { 9, "The two legged herbivore with a powerful headbutt", "\\Images\\Pachycephalosaurus.jpg", "Pachycephalosaurus", 199.99m, "00009" },
                    { 10, "A plated beheamoth with a powerful defensive tail", "\\Images\\Stegosaurus.jpg", "Stegosaurus", 199.99m, "00010" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketID",
                table: "BasketItem",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductID",
                table: "BasketItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
