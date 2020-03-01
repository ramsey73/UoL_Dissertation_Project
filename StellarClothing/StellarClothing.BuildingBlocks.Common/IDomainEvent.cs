using MassTransit;
using System;

namespace StellarClothing.BuildingBlocks.Domain
{
    public interface IDomainEvent : CorrelatedBy<Guid>
    {
        DateTime OccurredOn { get; }
    }
}
