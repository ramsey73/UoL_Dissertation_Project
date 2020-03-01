using System;
using System.Linq;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StellarClothing.BuildingBlocks.Infrastructure.Events;
using StellarClothing.Ordering.Api.Models;
using StellarClothing.Ordering.Api.Services;
using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace StellarClothing.Ordering.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IApplicationService _applicationService;
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(
            IBus bus,
            IApplicationService applicationService,
            IOrderRepository repository,
            ILogger<OrderController> logger)
        {
            _bus = bus;
            _applicationService = applicationService;
            _repository = repository;
            _logger = logger;
        }

        // POST api/orders
        [HttpPost]
        [Route("checkout")]
        public async void Checkout([FromBody]SubmitOrder submittedOrder)
        {
            _logger.LogInformation($"A new order has been accepted for customer id '{submittedOrder.CustomerId}'.");

            var customer = await _applicationService.GetCustomerAsync(submittedOrder.CustomerId);
            if (customer == null)
            {
                return;
            }

            var order = new Order() { CustomerId = submittedOrder.CustomerId, Status = OrderStatus.Submitted };

            order.Total = 0.0;
            foreach (var item in submittedOrder.Items)
            {
                var product = await _applicationService.GetProductByIDAsync(item.ProductId);
                if (product != null)
                {
                    order.Total += item.Quantity * product.Price;
                    order.Items.Add(new OrderItem() { ProductId = item.ProductId, Quantity = item.Quantity, Name = product.Name, Price = product.Price });
                }
            }

            await _repository.Add(order);

            _logger.LogInformation($"Created order {order.Id} for customer {customer.Id} for the total amount of {order.Total}");

            await _bus.Send(new OrderSubmittedEvent()
            {
                CustomerId = customer.Id,
                OrderId = order.Id,
                Total = order.Total,
                OccurredOn = DateTime.Now,
                Products = order.Items.Select(t => new BuildingBlocks.Infrastructure.Events.Item() { ProductId = t.ProductId, Quantity = t.Quantity }).ToArray()
            });
        }
    }
}