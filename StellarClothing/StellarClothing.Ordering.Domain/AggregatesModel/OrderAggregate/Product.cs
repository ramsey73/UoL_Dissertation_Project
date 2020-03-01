using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
