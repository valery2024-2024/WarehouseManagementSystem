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

    public Product? GetProductById(Guid id)
    {
        return _productRepository.GetById(id);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.Update(product);
    }

    public IReadOnlyCollection<Product> FindByName(string name)
    {
        return _productRepository
            .GetAll()
            .Where(p => p.Name
                .Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyCollection<Product> GetProductsSortedByPrice()
    {
        return _productRepository
            .GetAll()
            .OrderBy(p => p.Price)
            .ToList();
    }

    public IReadOnlyCollection<Product> GetProductsSortedByQuantity()
    {
        return _productRepository
            .GetAll()
            .OrderByDescending(p => p.Quantity)
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

    public int GetTotalProductsCount()
    {
        return _productRepository
            .GetAll()
            .Count;
    }

    public Product? GetMostExpensiveProduct()
    {
        return _productRepository
            .GetAll()
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();
    }

    public Product? GetCheapestProduct()
    {
        return _productRepository
            .GetAll()
            .OrderBy(p => p.Price)
            .FirstOrDefault();
    }

    public decimal GetAveragePrice()
    {
        var products = _productRepository.GetAll();

        if (!products.Any())
        {
            return 0;
        }

        return products.Average(p => p.Price);
    }
}