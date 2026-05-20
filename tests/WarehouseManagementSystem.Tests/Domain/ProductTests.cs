using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Domain.Exceptions;

namespace WarehouseManagementSystem.Tests.Domain;

public class ProductTests
{
    [Fact]
    public void Constructor_Should_Create_Product_When_Data_Is_Valid()
    {
        var product = new Product("Laptop", 50000, 5);

        Assert.Equal("Laptop", product.Name);
        Assert.Equal(50000, product.Price);
        Assert.Equal(5, product.Quantity);
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Price_Is_Negative()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product("Laptop", -100, 5);
        });
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Quantity_Is_Negative()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product("Laptop", 50000, -1);
        });
    }

    [Fact]
    public void AddQuantity_Should_Increase_Quantity()
    {
        var product = new Product("Laptop", 50000, 5);

        product.AddQuantity(3);

        Assert.Equal(8, product.Quantity);
    }

    [Fact]
    public void RemoveQuantity_Should_Throw_When_Not_Enough_Stock()
    {
        var product = new Product("Laptop", 50000, 5);

        Assert.Throws<InsufficientStockException>(() =>
        {
            product.RemoveQuantity(10);
        });
    }
}