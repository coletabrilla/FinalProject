using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DataModel
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //need off to update table migration
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=COLE\\SQLEXPRESS;DATABASE=finalproj;Integrated Security=SSPI;TrustServerCertificate=true");
            //Server=DESKTOP-BIVTLHI - edwin
            //Server=COLE\\SQLEXPRESS - cole
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ProductInventoryTable
            //Table
            modelBuilder.Entity<Product>().ToTable("Products");
            //field names

            modelBuilder.Entity<Product>().Property(p => p.Stock).HasColumnName("Stock");
            modelBuilder.Entity<Product>().Property(p => p.Type).HasColumnName("Type");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("Price");
            modelBuilder.Entity<Product>().Property(p => p.Qty).HasColumnName("Qty");
            modelBuilder.Entity<Product>().Property(p => p.Supplier).HasColumnName("Supplier");

            modelBuilder.Entity<Product>().Property(p => p.DateStocked).HasColumnName("DateStocked");

            //data types

            modelBuilder.Entity<Product>().Property(p => p.Type).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<Product>().Property(p => p.Supplier).HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Qty = 3,
                Supplier = "Sha"
                
            });

        }

    }

}

   



