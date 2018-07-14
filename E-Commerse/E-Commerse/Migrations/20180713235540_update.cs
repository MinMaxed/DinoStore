using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerse.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "\\Images\\Triceratops.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "\\Images\\Pteradactyl.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "\\Images\\Brachiosaurus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "\\Images\\Ankylosaurus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "\\Images\\Velociraptor.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "\\Images\\Archeopteryx.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "\\Images\\Allosaurus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "\\Images\\Pachycephalosaurus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "\\Images\\Stegosaurus.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/4/4d/Knight_Triceratops.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "http://images.dinosaurpictures.org/pterodactyl-adrian-chesterman_54f6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "https://en.wikipedia.org/wiki/Brachiosaurus#/media/File:Brachiosaurus_NT_new.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "https://vignette.wikia.nocookie.net/ark-survival-evolved/images/0/07/Ankylosaurus-2.png/revision/latest?cb=20150620091126&path-prefix=fr");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://vignette.wikia.nocookie.net/jurassicpark/images/1/12/Velociraptor-detail-header.png/revision/latest?cb=20150420213742");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "https://en.wikipedia.org/wiki/Archaeopteryx#/media/File:Archaeopteryx_lithographica_by_durbed.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/d/d2/Allosaurus4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "https://en.wikipedia.org/wiki/Pachycephalosaurus#/media/File:Pachycephalosaurus_Reconstruction.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "https://upload.wikimedia.org/wikipedia/commons/a/a1/Stego.jpg");
        }
    }
}
