using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly ShoppingCartDbContext _shoppingCartDbContext;

        public OrderRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _shoppingCartDbContext.Order.ToListAsync();
        }

        public async Task<Order> GetOrder(int OrderId)
        {
            return await _shoppingCartDbContext.Order
                .FirstOrDefaultAsync(e => e.OrderId == OrderId);
        }

        public async Task<Order> AddOrder(Order Order)
        {
            var result = await _shoppingCartDbContext.Order.AddAsync(Order);
            await _shoppingCartDbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}