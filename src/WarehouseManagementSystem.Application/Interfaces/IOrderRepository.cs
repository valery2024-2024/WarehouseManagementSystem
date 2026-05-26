using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Interfaces;

public interface IOrderRepository
{
    void Add(Order order);

    IReadOnlyCollection<Order> GetAll();
}