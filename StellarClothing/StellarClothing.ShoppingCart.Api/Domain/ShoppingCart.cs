using StellarClothing.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;

namespace StellarClothing.ShoppingCart.Api.Domain
{
    public class ShoppingCart : Entity<int>
    {
        public int CustomerId { get; private set; }

        public double CartTotal { get; private set; }

        public bool IsCheckout { get; private set; }

        public ICollection<Product> CartItems { get; private set; } = new List<Product>();
    }
}
