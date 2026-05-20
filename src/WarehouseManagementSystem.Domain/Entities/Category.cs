namespace WarehouseManagementSystem.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Category name cannot be empty.");
        }

        Id = Guid.NewGuid();
        Name = name;
    }
}