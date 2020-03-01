using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class PaymentAcceptedEvent : IDomainEvent
    {
        public PaymentAcceptedEvent()
        {
        }

        public Guid CorrelationId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public double Total { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
