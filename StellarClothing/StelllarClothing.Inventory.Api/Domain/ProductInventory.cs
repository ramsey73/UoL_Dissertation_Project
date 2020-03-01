using StellarClothing.BuildingBlocks.Domain;

namespace StelllarClothing.Inventory.Api.Domain
{
    public class ProductInventory : Entity<int>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
