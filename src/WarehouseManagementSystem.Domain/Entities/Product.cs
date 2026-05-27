using WarehouseManagementSystem.Domain.Exceptions;

namespace WarehouseManagementSystem.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        if (price < 0)
        {
            throw new ArgumentException("Ціна не може бути від'ємною.");
        }

        if (quantity < 0)
        {
            throw new ArgumentException("Кількість не може бути від'ємною.");
        }

        Id = Guid.NewGuid();

        Name = name;

        Price = price;

        Quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Кількість не може бути від'ємною.");
        }

        Quantity += amount;
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Кількість не може бути від'ємною.");
        }

        if (amount > Quantity)
        {
            throw new InsufficientStockException("Недостатньо товару на складі.");
        }

        Quantity -= amount;
    }

    public override string ToString()
    {
        return $"ID: {Id} | {Name} | Price: {Price} | Quantity: {Quantity}";
    }
}