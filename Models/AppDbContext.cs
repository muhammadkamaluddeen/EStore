using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EStore.Models
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

       }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationDetail> ReservationDetails{ get; set; }



        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public string WebRootPath { get; internal set; }
        public DbSet<EStore.Models.ShoppingCart> ShoppingCart { get; set; }
    }
}
