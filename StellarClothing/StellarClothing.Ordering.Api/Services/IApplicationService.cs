using StellarClothing.Ordering.Domain.AggregatesModel.CustomerAggregate;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Threading.Tasks;

namespace StellarClothing.Ordering.Api.Services
{
    public interface IApplicationService
    {
        Task<Customer> GetCustomerAsync(int id);

        Task<Product> GetProductByIDAsync(int id);
    }
}
