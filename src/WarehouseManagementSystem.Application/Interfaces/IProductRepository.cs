using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Interfaces;

public interface IProductRepository
{
    void Add(Product product);

    IReadOnlyCollection<Product> GetAll();

    Product? GetById(Guid id);
    void Update(Product product);
}