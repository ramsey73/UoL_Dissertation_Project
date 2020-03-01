using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Catalog.Domain
{
    public class Size : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
