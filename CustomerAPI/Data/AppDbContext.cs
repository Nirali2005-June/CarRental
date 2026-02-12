using System.Collections.Generic;
using System.Reflection.Emit;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                        .ToTable("Customer");
        }
    }
}
