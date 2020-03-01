using Microsoft.EntityFrameworkCore;
using StelllarClothing.Inventory.Api.Domain;

namespace StelllarClothing.Inventory.Api.Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {

        }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<ProductInventory> ProductInventories { get; set; }
    }
}
