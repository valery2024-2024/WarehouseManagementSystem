using WarehouseManagementSystem.Application.Strategies;

namespace WarehouseManagementSystem.Application.Factories;

public static class DiscountStrategyFactory
{
    public static IDiscountStrategy Create(string discountType)
    {
        return discountType.ToLower() switch
        {
            "silver" => new SilverDiscountStrategy(),
            "gold" => new GoldDiscountStrategy(),
            _ => new RegularDiscountStrategy()
        };
    }
}