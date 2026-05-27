using System.Text.Json;
using WarehouseManagementSystem.Application.Interfaces;
using WarehouseManagementSystem.Domain.Entities;

namespace WarehouseManagementSystem.Infrastructure.Persistence;

public class JsonProductDataStore : IDataStore<Product>
{
    private readonly string _filePath;

    public JsonProductDataStore(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<IReadOnlyCollection<Product>> LoadAsync(
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
        {
            return new List<Product>();
        }

        try
        {
            string json = await File.ReadAllTextAsync(
                _filePath,
                cancellationToken);

            var products = JsonSerializer.Deserialize<List<Product>>(json);

            return products ?? new List<Product>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Помилка: JSON файл пошкоджений.");

            return new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка завантаження: {ex.Message}");

            return new List<Product>();
        }
    }

    public async Task SaveAsync(
        IReadOnlyCollection<Product> items,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(items, options);

            await File.WriteAllTextAsync(
                _filePath,
                json,
                cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка збереження: {ex.Message}");
        }
    }
}