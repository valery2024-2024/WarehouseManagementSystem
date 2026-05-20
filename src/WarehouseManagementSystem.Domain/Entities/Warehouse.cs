namespace WarehouseManagementSystem.Domain.Entities;

public class Warehouse
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    public Warehouse(string name, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Warehouse name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException("Address cannot be empty.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Address = address;
    }
}