using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace StellarClothing.ShoppingCart.Api.Domain
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        IEnumerable<string> GetUsers();
    }
}
