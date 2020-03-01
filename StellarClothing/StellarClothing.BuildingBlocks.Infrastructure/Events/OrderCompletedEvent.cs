using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class OrderCompletedEvent : IDomainEvent
    {
        public OrderCompletedEvent()
        {
        }

        public Guid CorrelationId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
