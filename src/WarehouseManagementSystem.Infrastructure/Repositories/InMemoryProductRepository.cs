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

        SaveChanges();
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

        SaveChanges();
    }

    private void SaveChanges()
    {
        _dataStore
            .SaveAsync(_products)
            .GetAwaiter()
            .GetResult();
    }
}