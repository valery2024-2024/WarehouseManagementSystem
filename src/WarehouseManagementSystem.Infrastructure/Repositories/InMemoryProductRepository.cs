using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}