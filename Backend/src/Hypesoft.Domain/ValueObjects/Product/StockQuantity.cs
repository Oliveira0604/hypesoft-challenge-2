namespace Hypesoft.Domain.ValueObjects.Product;

public class StockQuantity
{
    public int Value { get; }

    public StockQuantity(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("A quantidade em estoque não pode ser negativa.");
        }

        Value = value;
    }
}