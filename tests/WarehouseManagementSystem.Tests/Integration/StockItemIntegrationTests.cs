using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Integration;

public class StockItemIntegrationTests
{
    [Fact]
    public void StockItem_Should_Create_Correctly()
    {
        // Arrange
        var product = new Product(
            "Laptop",
            50000,
            10);

        var warehouse = new Warehouse(
            "Main Warehouse",
            "Rivne");

        // Act
        var stockItem = new StockItem(
            product,
            warehouse,
            5);

        // Assert
        Assert.Equal(product, stockItem.Product);
        Assert.Equal(warehouse, stockItem.Warehouse);
        Assert.Equal(5, stockItem.Quantity);
    }

    [Fact]
    public void StockItem_Should_Have_Id()
    {
        // Arrange
        var product = new Product(
            "Mouse",
            1000,
            20);

        var warehouse = new Warehouse(
            "Storage",
            "Kyiv");

        // Act
        var stockItem = new StockItem(
            product,
            warehouse,
            3);

        // Assert
        Assert.NotEqual(
            Guid.Empty,
            stockItem.Id);
    }

    [Fact]
    public void IncreaseStock_Should_Increase_Quantity()
    {
        // Arrange
        var product = new Product(
            "Keyboard",
            2000,
            15);

        var warehouse = new Warehouse(
            "Warehouse",
            "Lviv");

        var stockItem = new StockItem(
            product,
            warehouse,
            5);

        // Act
        stockItem.IncreaseStock(3);

        // Assert
        Assert.Equal(8, stockItem.Quantity);
    }

    [Fact]
    public void DecreaseStock_Should_Decrease_Quantity()
    {
        // Arrange
        var product = new Product(
            "Monitor",
            7000,
            10);

        var warehouse = new Warehouse(
            "Warehouse",
            "Odesa");

        var stockItem = new StockItem(
            product,
            warehouse,
            6);

        // Act
        stockItem.DecreaseStock(2);

        // Assert
        Assert.Equal(4, stockItem.Quantity);
    }
}