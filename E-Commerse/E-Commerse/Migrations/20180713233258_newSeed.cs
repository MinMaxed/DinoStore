using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations
{
    public partial class newSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "King of the Dinos", "\\Images\\Tyrannosaurus.jpg", "Tyranosaurus", 199.99m, "00001" },
                    { 2, "3 times the power of a Rhinocerous", "https://upload.wikimedia.org/wikipedia/commons/4/4d/Knight_Triceratops.jpg", "Triceratops", 199.99m, "00002" },
                    { 3, "Soaring the skies", "http://images.dinosaurpictures.org/pterodactyl-adrian-chesterman_54f6.jpg", "Pteradactyl", 199.99m, "00003" },
                    { 4, "Grandpa of the giraffe", "https://en.wikipedia.org/wiki/Brachiosaurus#/media/File:Brachiosaurus_NT_new.jpg", "Brachiosaurus", 199.99m, "00004" },
                    { 5, "The walking tank of the Cretaceous", "https://vignette.wikia.nocookie.net/ark-survival-evolved/images/0/07/Ankylosaurus-2.png/revision/latest?cb=20150620091126&path-prefix=fr", "Ankylosaurus", 199.99m, "00005" },
                    { 6, "Pack hunting terror of the Creatceous", "https://vignette.wikia.nocookie.net/jurassicpark/images/1/12/Velociraptor-detail-header.png/revision/latest?cb=20150420213742", "Velociraptor", 199.99m, "00006" },
                    { 7, "The missing link", "https://en.wikipedia.org/wiki/Archaeopteryx#/media/File:Archaeopteryx_lithographica_by_durbed.jpg", "Archeopteryx", 199.99m, "00007" },
                    { 8, "Jurassic terror", "https://upload.wikimedia.org/wikipedia/commons/d/d2/Allosaurus4.jpg", "Allosaurus", 199.99m, "00008" },
                    { 9, "The two legged herbivore with a powerful headbutt", "https://en.wikipedia.org/wiki/Pachycephalosaurus#/media/File:Pachycephalosaurus_Reconstruction.jpg", "Pachycephalosaurus", 199.99m, "00009" },
                    { 10, "A plated beheamoth with a powerful defensive tail", "https://upload.wikimedia.org/wikipedia/commons/a/a1/Stego.jpg", "Stegosaurus", 199.99m, "00010" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
