using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Seed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PointOfSale.Data.Entities
{
    public class PointOfSaleDbContext : DbContext
    {
        public PointOfSaleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<OfferCategory> OfferCategories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<TraditionalBill> TraditionalBills { get; set; }
        public DbSet<ServiceBill> ServiceBills { get; set; }
        public DbSet<SubscriptionBill> SubscriptionBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataBaseSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class PointOfSaleContextFactory : IDesignTimeDbContextFactory<PointOfSaleDbContext>
    {
        public PointOfSaleDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();
            configuration
                .Providers
                .First()
                .TryGet("connectionStrings:add:PointOfSale:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<PointOfSaleDbContext>().UseSqlServer(connectionString).Options;
            return new PointOfSaleDbContext(options);
        }
    }
}


