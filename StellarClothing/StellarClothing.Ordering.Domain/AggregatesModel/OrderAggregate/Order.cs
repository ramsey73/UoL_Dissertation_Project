using StellarClothing.BuildingBlocks.Domain;
using System.Collections.Generic;
using System.Text;

namespace StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity<int>, IAggregateRoot
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public double Total { get; set; }

        public IList<OrderItem> Items { get; set; }
    }
}
