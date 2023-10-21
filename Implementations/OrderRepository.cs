using CustomerManagement.Data;
using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddOrder(Order order)
        {           
            context.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task<Order> FindById(int Id)
        {
             var order = await context.Orders.Include(x =>x.Products).Where(x => x.CustomerId == Id).FirstOrDefaultAsync();
             return order;           
        }

        public async Task<List<Order>> FindOrders(int customerId)
        {
            List<Order> orders = await context.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
            return orders;
        }

        public async Task UpdateOrder(Order order)
        {
            context.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
