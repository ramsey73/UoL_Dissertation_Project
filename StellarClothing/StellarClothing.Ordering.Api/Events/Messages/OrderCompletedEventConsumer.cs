using MassTransit;
using Microsoft.Extensions.Logging;
using StellarClothing.BuildingBlocks.Infrastructure.Events;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Threading.Tasks;

namespace StellarClothing.Ordering.Domain.Events.Messages
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderCompletedEventConsumer> _logger;

        public OrderCompletedEventConsumer(IOrderRepository orderRepository, ILogger<OrderCompletedEventConsumer> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            var order = await _orderRepository.GetByID(context.Message.OrderId);
            if (order != null)
            {
                order.Status &= ~OrderStatus.Submitted; 
                order.Status |= OrderStatus.Shipped;

                await _orderRepository.Update(order);
            }

            _logger.LogInformation($"Order {context.Message.OrderId} for customer {context.Message.CustomerId} has been marked as shipped");
        }
    }
}
