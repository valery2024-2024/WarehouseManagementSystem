using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;
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
    Console.WriteLine("3. Пошук товару");
    Console.WriteLine("4. Сортування по ціні");
    Console.WriteLine("5. Товари з малою кількістю");
    Console.WriteLine("6. Загальна вартість складу");
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

        case "3":
            FindProduct(productService);
            break;

        case "4":
            SortProductsByPrice(productService);
            break;

        case "5":
            ShowLowStockProducts(productService);
            break;

        case "6":
            ShowInventoryValue(productService);
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

        var product = new Product(name, price, quantity);
        productService.AddProduct(product);

        Console.WriteLine("Продукт успішно додано.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}

static void ViewProducts(ProductService productService)
{
    var products = productService.GetAllProducts();

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

static void FindProduct(ProductService productService)
{
    Console.Write("Введіть назву товару: ");

    string searchName = Console.ReadLine()!;

    var foundProduct = productService.FindByName(searchName);

    Console.WriteLine();

    if (foundProduct is null)
    {
        Console.WriteLine("Товар не знайдено.");
    }
    else
    {
        Console.WriteLine(
            $"Знайдено: {foundProduct.Name} | " +
            $"Price: {foundProduct.Price} | " +
            $"Quantity: {foundProduct.Quantity}");
    }
}

static void SortProductsByPrice(ProductService productService)
{
    var sortedProducts = productService.GetProductsSortedByPrice();

    Console.WriteLine();
    Console.WriteLine("=== Сортування по ціні ===");

    foreach (var product in sortedProducts)
    {
        Console.WriteLine(
            $"{product.Name} | " +
            $"Price: {product.Price} | " +
            $"Quantity: {product.Quantity}");
    }
}

static void ShowLowStockProducts(ProductService productService)
{
    Console.Write("Введіть мінімальну кількість: ");

    int minimumQuantity = int.Parse(Console.ReadLine()!);

    var lowStockProducts =
        productService.GetLowStockProducts(minimumQuantity);

    Console.WriteLine();
    Console.WriteLine("=== Товари з малою кількістю ===");

    if (lowStockProducts.Count == 0)
    {
        Console.WriteLine("Таких товарів немає.");
        return;
    }

    foreach (var product in lowStockProducts)
    {
        Console.WriteLine(
            $"{product.Name} | Quantity: {product.Quantity}");
    }
}

static void ShowInventoryValue(ProductService productService)
{
    decimal totalValue = productService.GetTotalInventoryValue();

    Console.WriteLine();
    Console.WriteLine(
        $"Загальна вартість складу: {totalValue}");
}