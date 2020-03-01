using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Ordering.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
