using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.Catalog.Domain
{
    public class Category : Entity<int>, IAggregateRoot
    {

        public string Name { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
