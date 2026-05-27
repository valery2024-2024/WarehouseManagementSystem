using WarehouseManagementSystem.Application.Strategies;

namespace WarehouseManagementSystem.Tests.Strategies;

public class DiscountStrategyTests
{
    [Fact]
    public void GoldDiscount_Should_Apply_10_Percent()
    {
        // Arrange
        var strategy = new GoldDiscountStrategy();
        decimal originalPrice = 1000;

        // Act
        var result = strategy.ApplyDiscount(originalPrice);

        // Assert
        Assert.Equal(900, result);
    }

    [Fact]
    public void SilverDiscount_Should_Apply_5_Percent()
    {
        // Arrange
        var strategy = new SilverDiscountStrategy();
        decimal originalPrice = 1000;

        // Act
        var result = strategy.ApplyDiscount(originalPrice);

        // Assert
        Assert.Equal(950, result);
    }

    [Fact]
    public void RegularDiscount_Should_Not_Change_Price()
    {
        // Arrange
        var strategy = new RegularDiscountStrategy();
        decimal originalPrice = 1000;

        // Act
        var result = strategy.ApplyDiscount(originalPrice);

        // Assert
        Assert.Equal(1000, result);
    }

    [Fact]
    public void GoldDiscount_Should_Work_With_Decimals()
    {
        // Arrange
        var strategy = new GoldDiscountStrategy();
        decimal originalPrice = 1999.99m;

        // Act
        var result = strategy.ApplyDiscount(originalPrice);

        // Assert
        Assert.Equal(1799.991m, result);
    }
}