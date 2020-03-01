using System;

namespace StellarClothing.Ordering.Api.Models
{
    public class SubmitOrder
    {
        public int CustomerId { get; set; }

        DateTime OrderDate { get; set; }

        public ProductItem[] Items { get; set; }
    }

    public class ProductItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
