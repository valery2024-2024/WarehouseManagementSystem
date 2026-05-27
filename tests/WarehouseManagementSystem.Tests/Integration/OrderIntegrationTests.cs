using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Infrastructure.Repositories;

namespace WarehouseManagementSystem.Tests.Integration;

public class OrderIntegrationTests
{
    [Fact]
    public void CreateOrder_Should_Decrease_Product_Quantity()
    {
        // Arrange
        var productRepository =
            new InMemoryProductRepository();

        var orderRepository =
            new InMemoryOrderRepository();

        var orderService = new OrderService(
            orderRepository,
            productRepository);

        var product = new Product(
            "Laptop",
            50000,
            10);

        productRepository.Add(product);

        // Act
        orderService.CreateOrder(
            product.Id,
            2,
            "none");

        var updatedProduct =
            productRepository.GetById(product.Id);

        // Assert
        Assert.NotNull(updatedProduct);

        Assert.Equal(
            8,
            updatedProduct!.Quantity);
    }
}