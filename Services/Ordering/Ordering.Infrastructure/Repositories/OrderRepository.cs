using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext orderContext) : base(orderContext)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByEmailAsync(string email)
    {
        var orders = await _orderContext.orders
            .Where(order => order.Email == email)
            .ToListAsync();

        return orders;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserNameAsync(string userName)
    {
        var orders = await _orderContext.orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        return orders;
    }
}
