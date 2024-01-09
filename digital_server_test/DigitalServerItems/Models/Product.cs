namespace DigitalServerItems.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
        public int ManufacturerCityId { get; set; }
    }
}
