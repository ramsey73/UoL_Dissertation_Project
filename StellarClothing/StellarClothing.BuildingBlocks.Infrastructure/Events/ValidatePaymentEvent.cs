using StellarClothing.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class ValidatePaymentEvent : IDomainEvent
    {
        public ValidatePaymentEvent()
        {

        }

        public Guid CorrelationId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public double Total { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
