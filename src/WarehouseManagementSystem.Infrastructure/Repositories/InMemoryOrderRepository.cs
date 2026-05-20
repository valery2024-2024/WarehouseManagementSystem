using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Infrastructure.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orders;
    }
}