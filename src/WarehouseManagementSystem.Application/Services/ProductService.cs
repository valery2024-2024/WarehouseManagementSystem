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

    public void AddProduct(Product product)
    {
        _productRepository.Add(product);
    }

    public IReadOnlyCollection<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public Product? FindByName(string name)
    {
        return _productRepository
            .GetAll()
            .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
    }

    public IReadOnlyCollection<Product> GetProductsSortedByPrice()
    {
        return _productRepository
            .GetAll()
            .OrderBy(p => p.Price)
            .ToList();
    }

    public IReadOnlyCollection<Product> GetLowStockProducts(int minimumQuantity)
    {
        return _productRepository
            .GetAll()
            .Where(p => p.Quantity <= minimumQuantity)
            .ToList();
    }

    public decimal GetTotalInventoryValue()
    {
        return _productRepository
            .GetAll()
            .Sum(p => p.Price * p.Quantity);
    }
}