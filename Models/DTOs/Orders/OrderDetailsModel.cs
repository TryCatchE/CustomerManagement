using System;
using System.Collections.Generic;

namespace CustomerManagement.Models.DTOs.Orders
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comments { get; set; }
        public OrderStatus Status { get; set; }
        public List<ProductDetailsModel> Products { get; set; }

    }

    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
