using App.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Context
{
    public class AppContext : DbContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Contract> Contracts { get; set; }

        DbSet<Delivery> Deliveries { get; set; }

        DbSet<Item> Items { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}