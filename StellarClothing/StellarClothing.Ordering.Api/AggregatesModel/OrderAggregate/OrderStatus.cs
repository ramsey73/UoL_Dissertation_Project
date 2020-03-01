using System;

namespace StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate
{
    [Flags]
    public enum OrderStatus
    {
        None = 0,
        Submitted = 1,
        Packed = 2,
        Payed = 4,
        Shipped = 8
    }
}
