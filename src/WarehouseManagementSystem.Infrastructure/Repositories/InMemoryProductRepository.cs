using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;
using WarehouseManagementSystem.Infrastructure.Persistence;

namespace WarehouseManagementSystem.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    private readonly IDataStore<Product> _dataStore;

    public InMemoryProductRepository()
    {
        _dataStore = new JsonProductDataStore(
            "data/products.json");

        _products = _dataStore
            .LoadAsync()
            .GetAwaiter()
            .GetResult()
            .ToList();
    }

    public void Add(Product product)
    {
        _products.Add(product);

        _dataStore
            .SaveAsync(_products)
            .GetAwaiter()
            .GetResult();
    }

    public void Update(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);

        if (index == -1)
        {
            return;
        }
        _products[index] = product;
        _dataStore.SaveAsync(_products).GetAwaiter().GetResult();
    }

    public IReadOnlyCollection<Product> GetAll()
    {
        return _products.AsReadOnly();
    }

    public Product? GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}