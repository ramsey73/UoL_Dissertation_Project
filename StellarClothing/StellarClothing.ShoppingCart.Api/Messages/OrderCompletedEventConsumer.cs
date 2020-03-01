using MassTransit;
using Microsoft.Extensions.Logging;
using StellarClothing.BuildingBlocks.Infrastructure.Events;
using StellarClothing.ShoppingCart.Api.Domain;
using System.Threading.Tasks;

namespace StellarClothing.ShoppingCart.Api.Messages
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        private readonly IShoppingCartRepository _repository;
        private readonly ILogger<OrderCompletedEventConsumer> _logger;
        public OrderCompletedEventConsumer(IShoppingCartRepository repository, ILogger<OrderCompletedEventConsumer> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            await _repository.Delete(context.Message.CustomerId);

            _logger.LogInformation($"Order {context.Message.OrderId} for customer {context.Message.CustomerId} removed from shopping cart.");
        }
    }
}
