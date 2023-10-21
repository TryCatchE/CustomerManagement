namespace CustomerManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
