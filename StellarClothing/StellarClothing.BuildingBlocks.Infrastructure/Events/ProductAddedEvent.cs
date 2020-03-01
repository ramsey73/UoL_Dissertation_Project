using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class ProductAddedEvent : IDomainEvent
    {
        public ProductAddedEvent()
        {

        }
        public Guid CorrelationId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public DateTime OccurredOn { get; set; }
        
    }
}
