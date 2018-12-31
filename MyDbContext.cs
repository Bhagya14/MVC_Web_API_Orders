using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Web_API_orders.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base("constr") { }
        public DbSet<OrderModel> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>().ToTable("tbl_orders");
            modelBuilder.Entity<OrderModel>().HasKey(p => p.orderid);
            modelBuilder.Entity<OrderModel>().Property(p => p.itemname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<OrderModel>().Property(p => p.customermobileno).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<OrderModel>().Property(p => p.itemprice).IsRequired();
            modelBuilder.Entity<OrderModel>().Property(p => p.itemquantity).IsRequired();
        }
    }
}