using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Domain;

public class OrderTests
{
    [Fact]
    public void Constructor_Should_Create_Order_Successfully()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var order = new Order(productId, 2, 1000);

        // Assert
        Assert.Equal(productId, order.ProductId);
        Assert.Equal(2, order.Quantity);
        Assert.Equal(1000, order.TotalPrice);
    }

    [Fact]
    public void Constructor_Should_Throw_When_Quantity_Is_Invalid()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new Order(productId, 0, 1000);
        });
    }

    [Fact]
    public void Constructor_Should_Throw_When_TotalPrice_Is_Invalid()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new Order(productId, 1, 0);
        });
    }
}