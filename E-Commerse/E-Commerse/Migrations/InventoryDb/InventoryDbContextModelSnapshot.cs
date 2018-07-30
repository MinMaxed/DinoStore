﻿// <auto-generated />
using ECommerse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerse.Migrations.InventoryDb
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerse.Models.Basket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserEmail");

                    b.HasKey("ID");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("ECommerse.Models.BasketItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasketID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("ECommerse.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ShippingAddress")
                        .IsRequired();

                    b.Property<decimal>("Total");

                    b.Property<bool>("TransactionCompleted");

                    b.Property<string>("UserEmail");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerse.Models.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ECommerse.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sku");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new { ID = 1, Description = "King of the Dinos", Image = "\\Images\\Tyrannosaurus.jpg", Name = "Tyranosaurus", Price = 1.99m, Sku = "00001" },
                        new { ID = 2, Description = "3 times the power of a Rhinocerous", Image = "\\Images\\Triceratops.jpg", Name = "Triceratops", Price = 1.99m, Sku = "00002" },
                        new { ID = 3, Description = "Soaring the skies", Image = "\\Images\\Pteradactyl.jpg", Name = "Pteradactyl", Price = 1.99m, Sku = "00003" },
                        new { ID = 4, Description = "Grandpa of the giraffe", Image = "\\Images\\Brachiosaurus.jpg", Name = "Brachiosaurus", Price = 1.99m, Sku = "00004" },
                        new { ID = 5, Description = "The walking tank of the Cretaceous", Image = "\\Images\\Anklyosaurus.jpg", Name = "Ankylosaurus", Price = 1.99m, Sku = "00005" },
                        new { ID = 6, Description = "Pack hunting terror of the Creatceous", Image = "\\Images\\Velociraptor.jpg", Name = "Velociraptor", Price = 1.99m, Sku = "00006" },
                        new { ID = 7, Description = "The missing link", Image = "\\Images\\Archaeopteryx.jpg", Name = "Archaeopteryx", Price = 1.99m, Sku = "00007" },
                        new { ID = 8, Description = "Jurassic terror", Image = "\\Images\\Allosaurus.jpg", Name = "Allosaurus", Price = 1.99m, Sku = "00008" },
                        new { ID = 9, Description = "The two legged herbivore with a powerful headbutt", Image = "\\Images\\Pachycephalosaurus.jpg", Name = "Pachycephalosaurus", Price = 1.99m, Sku = "00009" },
                        new { ID = 10, Description = "A plated beheamoth with a powerful defensive tail", Image = "\\Images\\Stegosaurus.jpg", Name = "Stegosaurus", Price = 1.99m, Sku = "00010" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
