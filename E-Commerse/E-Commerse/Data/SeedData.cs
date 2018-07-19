//using ECommerse.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ECommerse.Data
//{
//    public class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new InventoryDbContext(
//                serviceProvider.GetRequiredService<DbContextOptions<InventoryDbContext>>()))
//            {
//                if (context.Products.Any()) return;

//                context.Products.AddRange(
//                new Product
//                {
//                    Sku = "00001",
//                    Name = "Tyranosaurus",
//                    Price = 199.99m,
//                    Description = "King of the Dinos",
//                    Image = "/Images/Tyrannosaurus.jpg"
//                },

//                 new Product
//                 {
//                     Sku = "00002",
//                     Name = "Triceratops",
//                     Price = 199.99m,
//                     Description = "3 times the power of a Rhinocerous",
//                     Image = "/Images/Triceratops.jpg"
//                 },

//                 new Product()
//                 {
//                     Sku = "00003",
//                     Name = "Pteradactyl",
//                     Price = 199.99m,
//                     Description = "Soaring the skies",
//                     Image = "/Images/Pteradactyl.jpg"
//                 },

//                 new Product()
//                 {
//                     Sku = "00004",
//                     Name = "Brachiosaurus",
//                     Price = 199.99m,
//                     Description = "Grandpa of the giraffe",
//                     Image = "/Images/Brachiosaurus.jpg"
//                 },

//                 new Product()
//                 {
//                     Sku = "00005",
//                     Name = "Ankylosaurus",
//                     Price = 199.99m,
//                     Description = "The walking tank of the Cretaceous",
//                     Image = "/Images/Anklyosaurus.jpg"
//                 },

//                new Product()
//                {
//                    Sku = "00006",
//                    Name = "Velociraptor",
//                    Price = 199.99m,
//                    Description = "Pack hunting terror of the Creatceous",
//                    Image = "/Images/Velociraptor.jpg"
//                },

//                new Product()
//                {
//                    Sku = "00007",
//                    Name = "Archaeopteryx",
//                    Price = 199.99m,
//                    Description = "The missing link",
//                    Image = "/Images/Archaeopteryx.jpg"
//                },

//                 new Product()
//                 {
//                     Sku = "00008",
//                     Name = "Allosaurus",
//                     Price = 199.99m,
//                     Description = "Jurassic terror",
//                     Image = "/Images/Allosaurus.jpg"
//                 },

//                 new Product()
//                 {
//                     Sku = "00009",
//                     Name = "Pachycephalosaurus",
//                     Price = 199.99m,
//                     Description = "The two legged herbivore with a powerful headbutt",
//                     Image = "/Images/Pachycephalosaurus.jpg"
//                 },

//                 new Product()
//                 {
//                     Sku = "00010",
//                     Name = "Stegosaurus",
//                     Price = 199.99m,
//                     Description = "A plated beheamoth with a powerful defensive tail",
//                     Image = "/Images/Stegosaurus.jpg"
//                 });

//                context.SaveChanges();
//            }
//        }
//    }
//}
