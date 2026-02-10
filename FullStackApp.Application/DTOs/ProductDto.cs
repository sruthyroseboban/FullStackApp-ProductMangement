namespace FullStackApp.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
