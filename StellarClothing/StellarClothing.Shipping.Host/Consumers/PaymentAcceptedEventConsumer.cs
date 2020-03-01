using MassTransit;
using Microsoft.Extensions.Logging;
using StellarClothing.BuildingBlocks.Infrastructure.Events;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;
using StellarClothing.Ordering.Infrastructure.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.Shipping.Host.Consumers
{
    public class PaymentAcceptedEventConsumer : IConsumer<PaymentAcceptedEvent>
    {
        private readonly OrderContext _orderContext;
        private readonly ILogger<PaymentAcceptedEventConsumer> _logger;

        public PaymentAcceptedEventConsumer(OrderContext orderContext, ILogger<PaymentAcceptedEventConsumer> logger)
        {
            _orderContext = orderContext;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PaymentAcceptedEvent> context)
        {
            var order = _orderContext.Orders.FirstOrDefault(t => t.Id == context.Message.OrderId && t.CustomerId == context.Message.CustomerId);
            if (order != null)
            {
                order.Status |= OrderStatus.Payed;
                await _orderContext.SaveChangesAsync();
            }

            _logger.LogInformation($"Order {context.Message.OrderId} for customer {context.Message.CustomerId} has been marked as payed");
        }
    }
}
