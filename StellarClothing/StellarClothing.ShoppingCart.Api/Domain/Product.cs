using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.ShoppingCart.Api.Domain
{
    public class Product : Entity<int>
    {
        public int MyProperty { get; set; }
    }
}