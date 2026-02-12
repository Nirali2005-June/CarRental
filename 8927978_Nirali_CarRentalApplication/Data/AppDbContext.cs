using _8927978_Nirali_CarRentalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace _8927978_Nirali_CarRentalApplication.Data
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

