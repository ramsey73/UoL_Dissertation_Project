using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class ShoppingCartUpdatedEvent : IDomainEvent
    {
        public ShoppingCartUpdatedEvent()
        {

        }
        public Guid CorrelationId { get; set; }

        public int ProductId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
