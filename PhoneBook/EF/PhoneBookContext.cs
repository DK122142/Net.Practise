using System;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.EF
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhoneNumberStatus> Statuses { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumberStatus>().HasData(
                new(){Id = Guid.NewGuid(), StatusType = "Relevant"}, 
                new(){Id = Guid.NewGuid(), StatusType = "Irrelevant"},
                new(){Id = Guid.NewGuid(), StatusType = "Requires clarification"});
            
        }
    }
}
