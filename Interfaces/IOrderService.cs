using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListModel>> GetOrdersById(int customerId);      
        Task <OrderDetailsModel> GetOrderById(int orderId);
        Task AddOrder(OrderDetailsModel order);
        Task UpdateOrder(OrderDetailsModel order);
    }
}
