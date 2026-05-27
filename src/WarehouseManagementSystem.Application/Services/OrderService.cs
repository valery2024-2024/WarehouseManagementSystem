using WarehouseManagementSystem.Application.DTOs;
using WarehouseManagementSystem.Application.Factories;
using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    private readonly IProductRepository _productRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public Order CreateOrder(
        Guid productId,
        int quantity,
        string discountType)
    {
        var product = _productRepository.GetById(productId);

        if (product is null)
        {
            throw new InvalidOperationException(
                "Товар не знайдено.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Кількість повинна бути більше 0.");
        }

        if (product.Quantity < quantity)
        {
            throw new InvalidOperationException(
                "Недостатньо товару на складі.");
        }

        var strategy =
            DiscountStrategyFactory.Create(discountType);

        decimal originalPrice =
            product.Price * quantity;

        decimal finalPrice =
            strategy.ApplyDiscount(originalPrice);

        product.DecreaseQuantity(quantity);

        _productRepository.Update(product);

        var order = new Order(
            product.Id,
            quantity,
            finalPrice);

        _orderRepository.Add(order);

        return order;
    }

    public IReadOnlyCollection<Order> GetAllOrders()
    {
        return _orderRepository.GetAll();
    }

    public decimal GetTotalRevenue()
    {
        return _orderRepository
            .GetAll()
            .Sum(o => o.TotalPrice);
    }

    public int GetTotalOrdersCount()
    {
        return _orderRepository
            .GetAll()
            .Count;
    }

    public decimal GetAverageOrderValue()
    {
        var orders = _orderRepository.GetAll();

        if (!orders.Any())
        {
            return 0;
        }

        return orders.Average(o => o.TotalPrice);
    }

    public Order? GetLargestOrder()
    {
        return _orderRepository
            .GetAll()
            .OrderByDescending(o => o.TotalPrice)
            .FirstOrDefault();
    }

    public IReadOnlyCollection<OrderAnalyticsDto>
        GetOrderAnalytics()
    {
        return _orderRepository
            .GetAll()
            .Select(o => new OrderAnalyticsDto
            {
                OrderId = o.Id,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                TotalPrice = o.TotalPrice,
                CreatedAt = o.CreatedAt
            })
            .ToList();
    }

    public IReadOnlyCollection<ProductSalesDto>
        GetTopSellingProducts()
    {
        return _orderRepository
            .GetAll()
            .GroupBy(o => o.ProductId)
            .Select(group => new ProductSalesDto
            {
                ProductId = group.Key,
                TotalSold = group.Sum(x => x.Quantity),
                Revenue = group.Sum(x => x.TotalPrice)
            })
            .OrderByDescending(x => x.TotalSold)
            .ToList();
    }
}