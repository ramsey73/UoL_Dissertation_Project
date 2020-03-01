using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Catalog.Domain
{
    public class Brand : Entity<int>
    {
        public string Name { get; set; }
    }
}
