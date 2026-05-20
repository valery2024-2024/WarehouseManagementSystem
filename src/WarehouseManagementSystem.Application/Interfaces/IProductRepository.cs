using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Application.Interfaces;

public interface IProductRepository
{
    void Add(Product product);

    List<Product> GetAll();

    Product? GetById(Guid id);
}