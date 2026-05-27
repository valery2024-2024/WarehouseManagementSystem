namespace WarehouseManagementSystem.Application.Strategies;

public class RegularDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount;
    }
}