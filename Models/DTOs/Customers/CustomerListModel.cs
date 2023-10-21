﻿namespace CustomerManagement.Models.DTOs.Customers
{
    public class CustomerListModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
    }
}
