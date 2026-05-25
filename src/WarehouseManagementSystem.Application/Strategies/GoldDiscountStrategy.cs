namespace WarehouseManagementSystem.Application.Strategies;

public class GoldDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount * 0.90m;
    }
}