using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Catalog.Domain
{
    public class ProductPhoto : Entity<int>
    {
        public string Source { get; set; }
        public string Alt { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
