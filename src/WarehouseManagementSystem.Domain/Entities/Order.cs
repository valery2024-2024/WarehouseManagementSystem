namespace WarehouseManagementSystem.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal TotalPrice { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public string Status { get; private set; }

    public Order(
        Guid productId,
        int quantity,
        decimal totalPrice)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Кількість повинна бути більше 0.");
        }

        if (totalPrice <= 0)
        {
            throw new ArgumentException(
                "Сума повинна бути більше 0.");
        }

        Id = Guid.NewGuid();

        ProductId = productId;

        Quantity = quantity;

        TotalPrice = totalPrice;

        CreatedAt = DateTime.UtcNow;

        Status = "Created";
    }

    public void Complete()
    {
        Status = "Completed";
    }

    public void Cancel()
    {
        Status = "Cancelled";
    }
}