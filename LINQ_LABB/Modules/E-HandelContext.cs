using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_LABB.Modules
{
    public class E_HandelContext : DbContext
    {
        public E_HandelContext()
        {
            
        }

        public E_HandelContext(DbContextOptions<E_HandelContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        private static IConfiguration _configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CONNECTION"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
              
           
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}
