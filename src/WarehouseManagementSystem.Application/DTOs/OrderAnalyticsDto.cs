namespace WarehouseManagementSystem.Application.DTOs;

public class OrderAnalyticsDto
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }
}