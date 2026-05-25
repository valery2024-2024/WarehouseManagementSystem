namespace WarehouseManagementSystem.Application.Strategies;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}