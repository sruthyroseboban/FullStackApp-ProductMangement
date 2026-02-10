namespace FullStackApp.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime DateOfManufacture { get; set; }
    public DateTime DateOfExpiry { get; set; }
    public int CreatedByUserId { get; set; }
}
