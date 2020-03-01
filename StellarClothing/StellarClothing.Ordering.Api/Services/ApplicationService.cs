using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StellarClothing.Ordering.Domain.AggregatesModel.CustomerAggregate;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Net.Http;
using System.Threading.Tasks;

namespace StellarClothing.Ordering.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApplicationService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("DefaultClient");
            var customerServiceHost = _configuration["Services:Customer"];
            var response = await client.GetStringAsync($"http://{customerServiceHost}/api/customers/{id}");
            var customer = JsonConvert.DeserializeObject<Customer>(response);
            return customer;
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("DefaultClient");
            var catalogServiceHost = _configuration["Services:Catalog"];
            var response = await client.GetStringAsync($"http://{catalogServiceHost}/api/catalog/{id}");
            var product = JsonConvert.DeserializeObject<Product>(response);
            return product;
        }
    }
}
