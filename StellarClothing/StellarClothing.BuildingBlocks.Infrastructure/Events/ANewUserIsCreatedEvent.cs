using StellarClothing.BuildingBlocks.Domain;
using System;

namespace StellarClothing.BuildingBlocks.Infrastructure.Events
{
    public class ANewUserIsCreatedEvent : IDomainEvent
    {
        public ANewUserIsCreatedEvent()
        {
        }

        public Guid CorrelationId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
