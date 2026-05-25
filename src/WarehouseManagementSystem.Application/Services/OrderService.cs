using WarehouseManagementSystem.Application.DTOs;
using WarehouseManagementSystem.Application.Factories;
using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Application.Policies;
using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Domain.Exceptions;

namespace WarehouseManagementSystem.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    private readonly IProductRepository _productRepository;

    private readonly MinimumOrderPolicy _minimumOrderPolicy;

    private readonly StockAvailabilityPolicy _stockPolicy;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;

        _minimumOrderPolicy = new MinimumOrderPolicy();
        _stockPolicy = new StockAvailabilityPolicy();
    }

    public OrderSummaryDto ProcessOrder(CreateOrderRequest request)
    {
        var product = _productRepository
            .GetAll()
            .FirstOrDefault(p =>
                p.Name.Equals(
                    request.ProductName,
                    StringComparison.OrdinalIgnoreCase));

        if (product is null)
        {
            throw new InvalidOrderException("Товар не знайдено.");
        }

        ValidateOrder(product, request.Quantity);

        decimal totalPrice = product.Price * request.Quantity;

        var discountStrategy =
            DiscountStrategyFactory.Create(request.DiscountType);

        decimal finalPrice =
            discountStrategy.ApplyDiscount(totalPrice);

        var order = new Order();

        for (int i = 0; i < request.Quantity; i++)
        {
            order.AddProduct(product);
        }

        product.RemoveQuantity(request.Quantity);

        _productRepository.Update(product);

        _orderRepository.Add(order);

        return new OrderSummaryDto
        {
            OrderId = order.Id,
            ProductName = product.Name,
            Quantity = request.Quantity,
            TotalPrice = totalPrice,
            FinalPrice = finalPrice,
            CreatedAt = order.CreatedAt
        };
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.Add(order);
    }

    public IReadOnlyCollection<Order> GetOrders()
    {
        return _orderRepository.GetAll();
    }

    public void ValidateOrder(Product product, int quantity)
    {
        decimal totalAmount = product.Price * quantity;

        if (!_minimumOrderPolicy.IsValid(totalAmount))
        {
            throw new InvalidOrderException(
                "Мінімальна сума замовлення 500 грн.");
        }

        if (!_stockPolicy.IsAvailable(product, quantity))
        {
            throw new InvalidOrderException(
                "Недостатньо товару на складі.");
        }
    }
}