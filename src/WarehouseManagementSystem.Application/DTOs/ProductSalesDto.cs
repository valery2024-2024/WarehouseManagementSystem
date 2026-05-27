namespace WarehouseManagementSystem.Application.DTOs;

public class ProductSalesDto
{
    public Guid ProductId { get; set; }

    public int TotalSold { get; set; }

    public decimal Revenue { get; set; }
}