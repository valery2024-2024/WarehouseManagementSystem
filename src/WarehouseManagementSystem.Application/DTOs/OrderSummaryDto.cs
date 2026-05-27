namespace WarehouseManagementSystem.Application.DTOs;

public class OrderSummaryDto
{
    public Guid OrderId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal FinalPrice { get; set; }

    public DateTime CreatedAt { get; set; }
}