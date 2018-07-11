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

        public DbSet<Product> Products { get; set; }
    }
}
