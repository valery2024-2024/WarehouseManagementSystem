namespace WarehouseManagementSystem.Application.DTOs;

public class CreateOrderRequest
{
    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public string DiscountType { get; set; } = "Regular";
}