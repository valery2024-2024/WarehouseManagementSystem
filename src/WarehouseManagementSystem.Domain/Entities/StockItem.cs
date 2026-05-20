namespace WarehouseManagementSystem.Domain.Entities;

public class StockItem
{
    public Guid Id { get; private set; }

    public Product Product { get; private set; }

    public Warehouse Warehouse { get; private set; }

    public int Quantity { get; private set; }

    public StockItem(Product product, Warehouse warehouse, int quantity)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (warehouse == null)
        {
            throw new ArgumentNullException(nameof(warehouse));
        }

        if (quantity < 0)
        {
            throw new ArgumentException("Quantity cannot be negative.");
        }

        Id = Guid.NewGuid();
        Product = product;
        Warehouse = warehouse;
        Quantity = quantity;
    }

    public void IncreaseStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Quantity += amount;
    }

    public void DecreaseStock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (amount > Quantity)
        {
            throw new InvalidOperationException("Insufficient stock.");
        }

        Quantity -= amount;
    }
}