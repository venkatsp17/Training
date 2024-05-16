using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PizzaShopAPI.Contexts
{
    public class PizzaShopContext : DbContext 
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
