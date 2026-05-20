namespace WarehouseManagementSystem.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Product(string name, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty.");
        }

        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }

        if (quantity < 0)
        {
            throw new ArgumentException("Quantity cannot be negative.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (amount > Quantity)
        {
            throw new InvalidOperationException("Not enough items in stock.");
        }

        Quantity -= amount;
    }
}