using ECommerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Data
{
    public class SeedData 
    {
        Product Dinosaur1 = new Product()
        {
            Sku = "00001",
            Name = "Tyranosaurus",
            Price = 199.99m,
            Description = "King of the Dinos",
            Image = "https://en.wikipedia.org/wiki/Tyrannosaurus#/media/File:Feathered_Tyrannosaurus_model.jpg"
        };

        Product Dinosaur2 = new Product()
        {
            Sku = "00002",
            Name = "Triceratops",
            Price = 199.99m,
            Description = "3 times the power of a Rhinocerous",
            Image = "https://upload.wikimedia.org/wikipedia/commons/4/4d/Knight_Triceratops.jpg"
        };
        Product Dinosaur3 = new Product()
        {
            Sku = "00003",
            Name = "Pteradactyl",
            Price = 199.99m,
            Description = "Soaring the skies",
            Image = "http://images.dinosaurpictures.org/pterodactyl-adrian-chesterman_54f6.jpg"
        };
        Product Dinosaur4 = new Product()
        {
            Sku = "00004",
            Name = "Brachiosaurus",
            Price = 199.99m,
            Description = "Grandpa of the giraffe",
            Image = "https://en.wikipedia.org/wiki/Brachiosaurus#/media/File:Brachiosaurus_NT_new.jpg"
        };
        Product Dinosaur5 = new Product()
        {
            Sku = "00005",
            Name = "Ankylosaurus",
            Price = 199.99m,
            Description = "The walking tank of the Cretaceous",
            Image = "https://vignette.wikia.nocookie.net/ark-survival-evolved/images/0/07/Ankylosaurus-2.png/revision/latest?cb=20150620091126&path-prefix=fr"
        };
        Product Dinosaur6 = new Product()
        {
            Sku = "00006",
            Name = "Velociraptor",
            Price = 199.99m,
            Description = "Pack hunting terror of the Creatceous",
            Image = "https://vignette.wikia.nocookie.net/jurassicpark/images/1/12/Velociraptor-detail-header.png/revision/latest?cb=20150420213742"
        };
        Product Dinosaur7 = new Product()
        {
            Sku = "00007",
            Name = "Archeopteryx",
            Price = 199.99m,
            Description = "The missing link",
            Image = "https://en.wikipedia.org/wiki/Archaeopteryx#/media/File:Archaeopteryx_lithographica_by_durbed.jpg"
        };
        Product Dinosaur8 = new Product()
        {
            Sku = "00008",
            Name = "Allosaurus",
            Price = 199.99m,
            Description = "Jurassic terror",
            Image = "https://upload.wikimedia.org/wikipedia/commons/d/d2/Allosaurus4.jpg"
        };
        Product Dinosaur9 = new Product()
        {
            Sku = "00009",
            Name = "Pachycephalosaurus",
            Price = 199.99m,
            Description = "The two legged herbivore with a powerful headbutt",
            Image = "https://en.wikipedia.org/wiki/Pachycephalosaurus#/media/File:Pachycephalosaurus_Reconstruction.jpg"
        };
        Product Dinosaur10 = new Product()
        {
            Sku = "00010",
            Name = "Stegosaurus",
            Price = 199.99m,
            Description = "A plated beheamoth with a powerful defensive tail",
            Image = "https://upload.wikimedia.org/wikipedia/commons/a/a1/Stego.jpg"
        };
    }
}
