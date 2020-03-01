using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using StellarClothing.ShoppingCart.Api.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellarClothing.ShoppingCart.Api.Infrastructure.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ILogger<ShoppingCartRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public ShoppingCartRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<ShoppingCartRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public Task Add(Domain.ShoppingCart prod)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            await _database.KeyDeleteAsync(id.ToString());
        }

        public Task<IEnumerable<Domain.ShoppingCart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.ShoppingCart> GetByID(int id)
        {
            var data = await _database.StringGetAsync(id.ToString());
            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Domain.ShoppingCart>(data);
        }

        public IEnumerable<string> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Domain.ShoppingCart prod)
        {
            var result = await _database.StringSetAsync(prod.CustomerId.ToString(), JsonConvert.SerializeObject(prod));
            if (!result)
            {
                _logger.LogInformation("Failed to update the shopping cart");
            }

            await GetByID(prod.CustomerId);
        }
    }
}
