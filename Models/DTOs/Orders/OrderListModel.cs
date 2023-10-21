using System;

namespace CustomerManagement.Models.DTOs.Orders
{
    public class OrderListModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comments { get; set; }
        public OrderStatus Status { get; set; }
    }
}
