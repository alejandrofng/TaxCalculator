using Microsoft.EntityFrameworkCore;
using System;
namespace TaxCalculator.Models
{
    public class TaxCalculatorContext : DbContext
    {
        private readonly string _connectionString;
        public TaxCalculatorContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////dummy data to test the database
            modelBuilder.Entity<ItemType>().HasData(
                new ItemType(1, 25M),
                new ItemType(2, 0M)
                );
            modelBuilder.Entity<Order>().HasData(
                new Order("dummyOrder1", 78.75M),
                new Order("dummyOrder2", 0)
                );
            modelBuilder.Entity<Item>().HasData(
            new Item("dummyItemType1", 6, ItemType.Type1, 2.5M, "dummyOrder1"),
            new Item("dummyItemType2", 12, ItemType.Type2, 5, "dummyOrder2")
            );
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
