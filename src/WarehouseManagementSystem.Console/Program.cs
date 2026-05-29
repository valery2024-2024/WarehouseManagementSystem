using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.ConsoleApp.UI;
using WarehouseManagementSystem.Infrastructure.Repositories;

var productRepository = new InMemoryProductRepository();
var orderRepository = new InMemoryOrderRepository();

var productService = new ProductService(productRepository);

var orderService = new OrderService(
    orderRepository,
    productRepository);

var menu = new MainMenu(
    productService,
    orderService);

menu.Run();