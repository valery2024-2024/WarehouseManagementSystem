using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Integration;

public class SupplierIntegrationTests
{
    [Fact]
    public void Supplier_Should_Create_Correctly()
    {
        // Arrange & Act
        var supplier = new Supplier(
            "Tech Supplier",
            "tech@gmail.com");

        // Assert
        Assert.Equal(
            "Tech Supplier",
            supplier.Name);

        Assert.Equal(
            "tech@gmail.com",
            supplier.Email);
    }

    [Fact]
    public void Supplier_Should_Have_Id()
    {
        // Arrange & Act
        var supplier = new Supplier(
            "Company",
            "company@gmail.com");

        // Assert
        Assert.NotEqual(
            Guid.Empty,
            supplier.Id);
    }
}