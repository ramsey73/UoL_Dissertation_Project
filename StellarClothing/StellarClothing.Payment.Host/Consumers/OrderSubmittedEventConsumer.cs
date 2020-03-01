using MassTransit;
using Microsoft.Extensions.Logging;
using StellarClothing.BuildingBlocks.Infrastructure.Events;
using System.Threading.Tasks;

namespace StellarClothing.Payment.Host.Consumers
{
    public class OrderSubmittedEventConsumer : IConsumer<OrderSubmittedEvent>
    {
        private readonly ILogger<OrderSubmittedEventConsumer> _logger;

        public OrderSubmittedEventConsumer(ILogger<OrderSubmittedEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderSubmittedEvent> context)
        {
            _logger.LogInformation($"Initiating payment for customer {context.Message.CustomerId}, order {context.Message.OrderId} in total of {context.Message.Total}");

            await Task.Delay(5000); // simulate payment

            // Payment was accepted
            await context.Publish(new PaymentAcceptedEvent()
            {
                CorrelationId = context.Message.CorrelationId,
                OrderId = context.Message.OrderId,
                CustomerId = context.Message.CustomerId,
                Total = context.Message.Total
            });
        }
    }
}
