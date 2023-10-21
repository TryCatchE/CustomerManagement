using System.Collections.Generic;

namespace CustomerManagement.Models.DTOs.Customers
{
    public class CustomerDetailsModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public List<CustomerAddressDetails> Addresses { get; set; }
    }
    public class CustomerAddressDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string AdressName { get; set; }
        public string PostalCode { get; set; }
    }
}
