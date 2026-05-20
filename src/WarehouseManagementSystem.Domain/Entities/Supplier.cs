namespace WarehouseManagementSystem.Domain.Entities;

public class Supplier
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public Supplier(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Supplier name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}