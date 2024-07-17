using Microsoft.AspNetCore.Mvc.ViewEngines;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using KeyVaultTest.Models;

namespace KeyVaultTest.Contexts
{
    public class TempDB : DbContext
    {
       
            public TempDB(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Product> Products { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
           
                var products = new List<Product>
            {
                new Product {ProductID=1, Name = "Product A", Price = 100, PictureURL="https://vbucket.blob.core.windows.net/product-img/1.jpg" },
                new Product {ProductID=2, Name = "Product B", Price = 200, PictureURL="https://vbucket.blob.core.windows.net/product-img/2.jfif" },
                new Product {ProductID=3, Name = "Product C", Price = 300, PictureURL="https://vbucket.blob.core.windows.net/product-img/3.jfif" }
            };

                modelBuilder.Entity<Product>().HasData(products);
            }







    }
}
