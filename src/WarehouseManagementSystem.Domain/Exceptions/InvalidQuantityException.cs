namespace WarehouseManagementSystem.Domain.Exceptions;

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string message)
        : base(message)
    {
    }
}