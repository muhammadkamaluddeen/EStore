using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

       }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public string WebRootPath { get; internal set; }
    }
}
