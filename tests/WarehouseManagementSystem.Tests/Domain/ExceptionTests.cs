using WarehouseManagementSystem.Domain.Exceptions;

namespace WarehouseManagementSystem.Tests.Domain;

public class ExceptionTests
{
    [Fact]
    public void InsufficientStockException_Should_Set_Message()
    {
        // Arrange
        var message = "Недостатньо товару на складі";

        // Act
        var exception = new InsufficientStockException(message);

        // Assert
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void InvalidOrderException_Should_Set_Message()
    {
        // Arrange
        var message = "Замовлення некоректне";

        // Act
        var exception = new InvalidOrderException(message);

        // Assert
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void InvalidQuantityException_Should_Set_Message()
    {
        // Arrange
        var message = "Некоректна кількість";

        // Act
        var exception = new InvalidQuantityException(message);

        // Assert
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void InsufficientStockException_Should_Inherit_Exception()
    {
        // Arrange & Act
        var exception = new InsufficientStockException("Помилка");

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }

    [Fact]
    public void InvalidOrderException_Should_Inherit_Exception()
    {
        // Arrange & Act
        var exception = new InvalidOrderException("Помилка");

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }

    [Fact]
    public void InvalidQuantityException_Should_Inherit_Exception()
    {
        // Arrange & Act
        var exception = new InvalidQuantityException("Помилка");

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }
}