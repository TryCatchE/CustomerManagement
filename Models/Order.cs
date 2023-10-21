using System;
using System.Collections.Generic;

namespace CustomerManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public  DateTime OrderDate { get; set; }
        public string Comments { get; set; }       
        public OrderStatus Status { get; set; } 
        public ICollection<Product> Products { get; set; }
    }
}
