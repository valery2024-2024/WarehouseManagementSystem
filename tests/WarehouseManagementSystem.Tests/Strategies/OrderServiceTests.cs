using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Tests.Services;

public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_Should_Create_Order_When_Data_Is_Valid()
    {
        var productRepository = new FakeProductRepository();
        var orderRepository = new FakeOrderRepository();

        var product = new Product("Laptop", 50000, 5);
        productRepository.Add(product);

        var service = new OrderService(orderRepository, productRepository);

        var order = service.CreateOrder(product.Id, 2, "Regular");

        Assert.Equal(product.Id, order.ProductId);
        Assert.Equal(2, order.Quantity);
        Assert.Equal(100000, order.TotalPrice);
    }

    [Fact]
    public void CreateOrder_Should_Decrease_Product_Quantity()
    {
        var productRepository = new FakeProductRepository();
        var orderRepository = new FakeOrderRepository();

        var product = new Product("Laptop", 50000, 5);
        productRepository.Add(product);

        var service = new OrderService(orderRepository, productRepository);

        service.CreateOrder(product.Id, 2, "Regular");

        Assert.Equal(3, product.Quantity);
    }

    [Fact]
    public void CreateOrder_Should_Apply_Gold_Discount()
    {
        var productRepository = new FakeProductRepository();
        var orderRepository = new FakeOrderRepository();

        var product = new Product("Laptop", 1000, 5);
        productRepository.Add(product);

        var service = new OrderService(orderRepository, productRepository);

        var order = service.CreateOrder(product.Id, 1, "Gold");

        Assert.Equal(900, order.TotalPrice);
    }

    [Fact]
    public void CreateOrder_Should_Throw_When_Product_Does_Not_Exist()
    {
        var productRepository = new FakeProductRepository();
        var orderRepository = new FakeOrderRepository();

        var service = new OrderService(orderRepository, productRepository);

        Assert.Throws<InvalidOperationException>(() =>
        {
            service.CreateOrder(Guid.NewGuid(), 1, "Regular");
        });
    }

    [Fact]
    public void CreateOrder_Should_Throw_When_Quantity_Is_Greater_Than_Stock()
    {
        var productRepository = new FakeProductRepository();
        var orderRepository = new FakeOrderRepository();

        var product = new Product("Laptop", 50000, 1);
        productRepository.Add(product);

        var service = new OrderService(orderRepository, productRepository);

        Assert.Throws<InvalidOperationException>(() =>
        {
            service.CreateOrder(product.Id, 5, "Regular");
        });
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

    private class FakeOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public IReadOnlyCollection<Order> GetAll()
        {
            return _orders.AsReadOnly();
        }
    }
}