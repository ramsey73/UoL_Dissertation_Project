using Microsoft.EntityFrameworkCore;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace StellarClothing.Ordering.Infrastructure.Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>().HasMany(p => p.Items);
            modelBuilder.Entity<OrderItem>().HasKey(p => p.Id);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
