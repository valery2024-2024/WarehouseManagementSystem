namespace WarehouseManagementSystem.Application.Policies;

public class MinimumOrderPolicy
{
    private const decimal MinimumOrderAmount = 500;

    public bool IsValid(decimal orderAmount)
    {
        return orderAmount >= MinimumOrderAmount;
    }
}