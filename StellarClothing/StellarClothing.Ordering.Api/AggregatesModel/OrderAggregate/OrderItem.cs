using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity<int>
    {

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
