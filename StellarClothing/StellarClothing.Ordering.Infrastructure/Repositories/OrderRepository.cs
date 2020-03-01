using StellarClothing.Ordering.Domain.AggregatesModel.OrderAggregate;
using StellarClothing.Ordering.Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellarClothing.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _ordercontext;
        public OrderRepository(OrderContext ordercontext)
        {
            _ordercontext = ordercontext;
        }
        public async Task Add(Order prod)
        {
            await _ordercontext.Orders.AddAsync(prod);
            await _ordercontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await GetByID(id);
            if (order == null)
                return;

            _ordercontext.Orders.Remove(order);
            await _ordercontext.SaveChangesAsync();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByID(int id)
        {
            return await _ordercontext.Orders.FindAsync(id);
        }

        public async Task Update(Order prod)
        {
            if (prod == null)
                return;

            _ordercontext.Orders.Update(prod);
            await _ordercontext.SaveChangesAsync();
        }
    }
}
