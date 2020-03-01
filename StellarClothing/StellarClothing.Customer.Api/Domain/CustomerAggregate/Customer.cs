using StellarClothing.BuildingBlocks.Domain;

namespace StellarClothing.Customer.Api.Domain.CustomerAggregate
{
    public class Customer : Entity<int>, IAggregateRoot
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Birthday { get; set; }

        public string Location { get; set; }

        public Customer()
        {

        }
    }
}
