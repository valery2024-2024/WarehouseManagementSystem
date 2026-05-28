using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Infrastructure.Repositories;

namespace WarehouseManagementSystem.Tests.Integration;

public class PersistenceIntegrationTests
{
    [Fact]
    public void Repository_Should_Save_And_Return_Product()
    {
        // Arrange
        var repository =
            new InMemoryProductRepository();

        var product = new Product(
            "Phone",
            20000,
            3);

        // Act
        repository.Add(product);

        var savedProduct =
            repository.GetById(product.Id);

        // Assert
        Assert.NotNull(savedProduct);

        Assert.Equal(
            "Phone",
            savedProduct!.Name);

        Assert.Equal(
            20000,
            savedProduct.Price);
    }
}