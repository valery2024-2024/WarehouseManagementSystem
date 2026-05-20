namespace WarehouseManagementSystem.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public List<Product> Products { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Order()
    {
        Id = Guid.NewGuid();
        Products = new List<Product>();
        CreatedAt = DateTime.UtcNow;
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        Products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        return Products.Sum(p => p.Price);
    }
}