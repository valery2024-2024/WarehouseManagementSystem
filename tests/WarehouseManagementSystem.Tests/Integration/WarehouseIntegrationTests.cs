using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Integration;

public class WarehouseIntegrationTests
{
    [Fact]
    public void Warehouse_Should_Create_Correctly()
    {
        // Arrange & Act
        var warehouse = new Warehouse(
            "Main Warehouse",
            "Rivne");

        // Assert
        Assert.Equal(
            "Main Warehouse",
            warehouse.Name);

        Assert.Equal(
            "Rivne",
            warehouse.Address);
    }

    [Fact]
    public void Warehouse_Should_Have_Id()
    {
        // Arrange & Act
        var warehouse = new Warehouse(
            "Storage",
            "Kyiv");

        // Assert
        Assert.NotEqual(
            Guid.Empty,
            warehouse.Id);
    }
}