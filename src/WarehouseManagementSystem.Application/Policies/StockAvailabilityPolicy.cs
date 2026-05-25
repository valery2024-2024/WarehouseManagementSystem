using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Policies;

public class StockAvailabilityPolicy
{
    public bool IsAvailable(Product product, int requestedQuantity)
    {
        return product.Quantity >= requestedQuantity;
    }
}