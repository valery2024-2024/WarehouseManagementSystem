using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Infrastructure.Repositories;

namespace WarehouseManagementSystem.Tests.Integration;

public class ProductIntegrationTests
{
    [Fact]
    public void AddProduct_Should_Save_Product_In_Repository()
    {
        // Arrange
        var repository = new InMemoryProductRepository();

        var service = new ProductService(repository);

        var product = new Product(
            "Laptop",
            50000,
            5
        );

        // Act
        service.AddProduct(product);

        var products = repository.GetAll();

        // Assert
        Assert.Single(products);

        Assert.Equal("Laptop", products.First().Name);
    }
}