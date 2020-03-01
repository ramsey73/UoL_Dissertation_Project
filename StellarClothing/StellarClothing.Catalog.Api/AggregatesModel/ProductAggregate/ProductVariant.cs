using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Catalog.Domain
{
    public class ProductVariant : Entity<int>
    {
        public int ProductId { get; set; }
        public byte? SizeId { get; set; }
        public byte? ColorId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
    }
}
