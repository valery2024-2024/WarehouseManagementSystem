namespace WarehouseManagementSystem.Application.Strategies;

public class SilverDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount * 0.95m;
    }
}