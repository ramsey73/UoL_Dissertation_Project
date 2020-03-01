using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class OrderPackedEvent : IDomainEvent
    {
        public OrderPackedEvent()
        {

        }
        public Guid CorrelationId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
