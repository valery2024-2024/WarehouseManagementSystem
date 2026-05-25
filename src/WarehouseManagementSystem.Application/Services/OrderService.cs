using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Application.Policies;
using WarehouseManagementSystem.Domain.Exceptions;

namespace WarehouseManagementSystem.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly MinimumOrderPolicy _minimumOrderPolicy;
    private readonly StockAvailabilityPolicy _stockPolicy;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        _minimumOrderPolicy = new MinimumOrderPolicy();
        _stockPolicy = new StockAvailabilityPolicy();
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.Add(order);
    }

    public void ValidateOrder(Product product, int quantity)
    {
        decimal totalAmount = product.Price * quantity;

        if (!_minimumOrderPolicy.IsValid(totalAmount))
        {
            throw new InvalidOrderException("Мінімальна сума замовлення 500 грн.");
        }

        if (!_stockPolicy.IsAvailable(product, quantity))
        {
            throw new InvalidOrderException("Недостатньо товару на складі.");
        }
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetAll();
    }
}