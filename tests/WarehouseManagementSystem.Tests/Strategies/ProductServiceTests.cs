using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Services;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_Should_Add_Product_To_Repository()
    {
        var repository = new FakeProductRepository();
        var service = new ProductService(repository);

        var product = new Product("Laptop", 50000, 5);

        service.AddProduct(product);

        Assert.Single(service.GetAllProducts());
    }

    [Fact]
    public void GetProductById_Should_Return_Product_When_Product_Exists()
    {
        var repository = new FakeProductRepository();
        var service = new ProductService(repository);

        var product = new Product("Mouse", 800, 10);
        service.AddProduct(product);

        var result = service.GetProductById(product.Id);

        Assert.NotNull(result);
        Assert.Equal(product.Id, result!.Id);
    }

    [Fact]
    public void FindByName_Should_Return_Matching_Products()
    {
        var repository = new FakeProductRepository();
        var service = new ProductService(repository);

        service.AddProduct(new Product("Laptop Lenovo", 40000, 3));
        service.AddProduct(new Product("Laptop Asus", 35000, 4));
        service.AddProduct(new Product("Mouse", 800, 10));

        var result = service.FindByName("Laptop");

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetProductsSortedByPrice_Should_Return_Products_In_Ascending_Order()
    {
        var repository = new FakeProductRepository();
        var service = new ProductService(repository);

        service.AddProduct(new Product("Expensive", 1000, 1));
        service.AddProduct(new Product("Cheap", 100, 1));

        var result = service.GetProductsSortedByPrice().ToList();

        Assert.Equal("Cheap", result[0].Name);
        Assert.Equal("Expensive", result[1].Name);
    }

    [Fact]
    public void GetTotalInventoryValue_Should_Calculate_Total_Value()
    {
        var repository = new FakeProductRepository();
        var service = new ProductService(repository);

        service.AddProduct(new Product("Product 1", 100, 2));
        service.AddProduct(new Product("Product 2", 200, 3));

        var result = service.GetTotalInventoryValue();

        Assert.Equal(800, result);
    }

    private class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        public Product? GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);

            if (existingProduct is null)
            {
                return;
            }

            var index = _products.IndexOf(existingProduct);
            _products[index] = product;
        }
    }
}