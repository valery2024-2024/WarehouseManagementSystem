using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(string name, decimal price, int quantity)
    {
        var product = new Product(name, price, quantity);

        _productRepository.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetAll();
    }
}