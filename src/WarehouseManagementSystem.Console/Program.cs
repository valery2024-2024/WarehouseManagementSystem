using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Infrastructure.Repositories;

var productRepository = new InMemoryProductRepository();

var productService = new ProductService(productRepository);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== Система Управління Складом ===");
    Console.WriteLine("1. Додати товар");
    Console.WriteLine("2. Переглянути продукти");
    Console.WriteLine("0. ВИХІД");
    Console.Write("Виберіть варіант: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddProduct(productService);
            break;

        case "2":
            ViewProducts(productService);
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Недійсний варіант.");
            break;
    }
}

static void AddProduct(ProductService productService)
{
    try
    {
        Console.Write("Введіть назву продукту: ");
        string name = Console.ReadLine()!;

        Console.Write("Введіть ціну: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Введіть кількість: ");
        int quantity = int.Parse(Console.ReadLine()!);

        productService.AddProduct(name, price, quantity);

        Console.WriteLine("Продукт успішно додано.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void ViewProducts(ProductService productService)
{
    var products = productService.GetProducts();

    Console.WriteLine();
    Console.WriteLine("=== Продукти ===");

    if (products.Count == 0)
    {
        Console.WriteLine("Продукти не знайдено.");
        return;
    }

    foreach (var product in products)
    {
        Console.WriteLine(
            $"Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
    }
}