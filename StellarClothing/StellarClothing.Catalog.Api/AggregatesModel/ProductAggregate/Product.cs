using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Catalog.Domain
{
    public class Product : Entity<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public byte CategoryId { get; set; }
        public string InventoryNumber { get; set; }
        public short? BrandId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
