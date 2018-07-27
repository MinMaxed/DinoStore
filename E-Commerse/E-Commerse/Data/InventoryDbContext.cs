using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerse.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      ID = 1,
                      Sku = "00001",
                      Name = "Tyranosaurus",
                      Price = 1.99m,
                      Description = "King of the Dinos",
                      Image = @"\Images\Tyrannosaurus.jpg"
                  },

                 new Product
                 {
                     ID = 2,
                     Sku = "00002",
                     Name = "Triceratops",
                     Price = 1.99m,
                     Description = "3 times the power of a Rhinocerous",
                     Image = @"\Images\Triceratops.jpg"
                 },

                 new Product()
                 {
                     ID = 3,
                     Sku = "00003",
                     Name = "Pteradactyl",
                     Price = 1.99m,
                     Description = "Soaring the skies",
                     Image = @"\Images\Pteradactyl.jpg"
                 },

                 new Product()
                 {
                     ID = 4,
                     Sku = "00004",
                     Name = "Brachiosaurus",
                     Price = 1.99m,
                     Description = "Grandpa of the giraffe",
                     Image = @"\Images\Brachiosaurus.jpg"
                 },

                 new Product()
                 {
                     ID = 5,
                     Sku = "00005",
                     Name = "Ankylosaurus",
                     Price = 1.99m,
                     Description = "The walking tank of the Cretaceous",
                     Image = @"\Images\Anklyosaurus.jpg"
                 },

                new Product()
                {
                    ID = 6,
                    Sku = "00006",
                    Name = "Velociraptor",
                    Price = 1.99m,
                    Description = "Pack hunting terror of the Creatceous",
                    Image = @"\Images\Velociraptor.jpg"
                },

                new Product()
                {
                    ID = 7,
                    Sku = "00007",
                    Name = "Archaeopteryx",
                    Price = 1.99m,
                    Description = "The missing link",
                    Image = @"\Images\Archaeopteryx.jpg"
                },

                 new Product()
                 {
                     ID = 8,
                     Sku = "00008",
                     Name = "Allosaurus",
                     Price = 1.99m,
                     Description = "Jurassic terror",
                     Image = @"\Images\Allosaurus.jpg"
                 },

                 new Product()
                 {
                     ID = 9,
                     Sku = "00009",
                     Name = "Pachycephalosaurus",
                     Price = 1.99m,
                     Description = "The two legged herbivore with a powerful headbutt",
                     Image = @"\Images\Pachycephalosaurus.jpg"
                 },

                 new Product()
                 {
                     ID = 10,
                     Sku = "00010",
                     Name = "Stegosaurus",
                     Price = 1.99m,
                     Description = "A plated beheamoth with a powerful defensive tail",
                     Image = @"\Images\Stegosaurus.jpg"
                 }
                );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
