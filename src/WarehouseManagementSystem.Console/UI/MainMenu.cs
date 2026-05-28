using WarehouseManagementSystem.Application.Services;
using WarehouseManagementSystem.Domain.Entities;
using Console = System.Console;

namespace WarehouseManagementSystem.ConsoleApp.UI;

public class MainMenu
{
    private readonly ProductService _productService;
    private readonly OrderService _orderService;

    public MainMenu(
        ProductService productService,
        OrderService orderService)
    {
        _productService = productService;
        _orderService = orderService;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    ViewProducts();
                    break;

                case "3":
                    FindProduct();
                    break;

                case "4":
                    SortProductsByPrice();
                    break;

                case "5":
                    ShowLowStockProducts();
                    break;

                case "6":
                    ShowInventoryValue();
                    break;

                case "7":
                    CreateOrder();
                    break;

                case "8":
                    ShowOrderAnalytics();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Недійсний варіант.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Система Управління Складом ===");
        Console.WriteLine("1. Додати товар");
        Console.WriteLine("2. Переглянути продукти");
        Console.WriteLine("3. Пошук товару");
        Console.WriteLine("4. Сортування по ціні");
        Console.WriteLine("5. Товари з малою кількістю");
        Console.WriteLine("6. Загальна вартість складу");
        Console.WriteLine("7. Оформити замовлення");
        Console.WriteLine("8. Аналітика замовлень");
        Console.WriteLine("0. ВИХІД");
        Console.Write("Виберіть варіант: ");
    }

    private void AddProduct()
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

            _productService.AddProduct(product);

            Console.WriteLine("Продукт успішно додано.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void ViewProducts()
    {
        var products = _productService.GetAllProducts();

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
                $"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
        }
    }

    private void FindProduct()
    {
        Console.Write("Введіть назву товару: ");
        string searchName = Console.ReadLine()!;

        var foundProducts = _productService.FindByName(searchName);

        Console.WriteLine();

        if (foundProducts.Count == 0)
        {
            Console.WriteLine("Товар не знайдено.");
            return;
        }

        foreach (var product in foundProducts)
        {
            Console.WriteLine(
                $"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
        }
    }

    private void SortProductsByPrice()
    {
        var sortedProducts = _productService.GetProductsSortedByPrice();

        Console.WriteLine();
        Console.WriteLine("=== Сортування по ціні ===");

        foreach (var product in sortedProducts)
        {
            Console.WriteLine(
                $"{product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
        }
    }

    private void ShowLowStockProducts()
    {
        Console.Write("Введіть мінімальну кількість: ");
        int minimumQuantity = int.Parse(Console.ReadLine()!);

        var lowStockProducts =
            _productService.GetLowStockProducts(minimumQuantity);

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

    private void ShowInventoryValue()
    {
        decimal totalValue = _productService.GetTotalInventoryValue();

        Console.WriteLine();
        Console.WriteLine($"Загальна вартість складу: {totalValue}");
    }

    private void CreateOrder()
    {
        try
        {
            Console.Write("Введіть ID товару: ");
            Guid productId = Guid.Parse(Console.ReadLine()!);

            Console.Write("Введіть кількість: ");
            int quantity = int.Parse(Console.ReadLine()!);

            Console.Write("Тип знижки (Regular/Silver/Gold): ");
            string discountType = Console.ReadLine()!;

            var order = _orderService.CreateOrder(
                productId,
                quantity,
                discountType);

            Console.WriteLine();
            Console.WriteLine("=== Замовлення оформлено ===");
            Console.WriteLine($"Order ID: {order.Id}");
            Console.WriteLine($"Product ID: {order.ProductId}");
            Console.WriteLine($"Quantity: {order.Quantity}");
            Console.WriteLine($"Total Price: {order.TotalPrice}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"Created At: {order.CreatedAt}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void ShowOrderAnalytics()
    {
        Console.WriteLine();
        Console.WriteLine("=== Аналітика замовлень ===");

        var orders = _orderService.GetAllOrders();

        Console.WriteLine($"Кількість замовлень: {orders.Count}");

        decimal total = orders.Sum(order => order.TotalPrice);

        Console.WriteLine($"Загальна сума замовлень: {total}");
    }
}