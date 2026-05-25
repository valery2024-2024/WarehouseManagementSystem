using WarehouseManagementSystem.Application.Strategies;

namespace WarehouseManagementSystem.Application.Services;

public class DiscountService
{
    public decimal CalculateDiscountedPrice(
        decimal amount,
        IDiscountStrategy strategy)
    {
        return strategy.ApplyDiscount(amount);
    }
}