using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class OrderSubmittedEvent : IDomainEvent
    {
        public OrderSubmittedEvent()
        {
        }

        public Guid CorrelationId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public double Total { get; set; }

        public Item[] Products { get; set; }

        public DateTime OccurredOn { get; set; }
    }

    public class Item
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
