using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> FindOrders(int customerId);
        Task <Order> FindById(int Id);
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
