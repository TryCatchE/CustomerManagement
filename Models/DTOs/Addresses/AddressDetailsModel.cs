namespace CustomerManagement.Models.DTOs.Addresses
{
    public class AddressDetailsModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string AdressName { get; set; }
        public string PostalCode { get; set; }

    }
}
