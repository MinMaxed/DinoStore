using ECommerse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerse.Data
{
    public class ECommerseDBContext : DbContext
    {
        //private readonly ImagesContext _context;
        //private readonly IConfiguration Configuration;
        public ECommerseDBContext(DbContextOptions<ECommerseDBContext>options) : base(options)
        { }


        DbSet<Product> Dinosaurs { get; set; }
    }
}
