using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task AddOrder(OrderDetailsModel order)
        {
            var newOrder = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                AddressId = order.AddressId,
                Status = order.Status,
                Comments = order.Comments,
                Products = order.Products.Select(x => new Product
                {
                    Price = x.Price,
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    OrderId = order.Id

                }).ToList()
            };
            await orderRepository.AddOrder(newOrder);
        }

        public async Task<OrderDetailsModel> GetOrderById(int orderId)
        {
            Order order = await orderRepository.FindById(orderId);
            var result = new OrderDetailsModel
            {
                Id = order.Id,
                AddressId = order.AddressId,
                Comments = order.Comments,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Products = order.Products.Select(x => new ProductDetailsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type
                }).ToList()
            };
            return result;
        }

        public async Task<List<OrderListModel>> GetOrdersById(int customerId)
        {
            var orders = await orderRepository.FindOrders(customerId);
            var result = orders.Select(x => new OrderListModel
            {
                Id=x.Id,
                AddressId = x.AddressId,
                Comments = x.Comments,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate,
                Status = x.Status,
            }).ToList();
            return result;
        }  


        public async Task UpdateOrder(OrderDetailsModel order)
        {
            var UpdateOrder = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                AddressId = order.AddressId,
                Status = order.Status,
                Comments = order.Comments,
                Products = order.Products.Select(x => new Product
                {
                    Price = x.Price,
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    OrderId = order.Id

                }).ToList()
            };
            await orderRepository.UpdateOrder(UpdateOrder);

        }
    }
}
