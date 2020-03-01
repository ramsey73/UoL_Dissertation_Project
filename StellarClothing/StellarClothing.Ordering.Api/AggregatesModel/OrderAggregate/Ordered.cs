namespace StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class Ordered
    {
        public int CustomerId { get; set; }

        public Item[] Items { get; set; }
    }
}
