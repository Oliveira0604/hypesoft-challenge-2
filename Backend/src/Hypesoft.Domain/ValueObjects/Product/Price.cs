namespace Hypesoft.Domain.ValueObjects.Product;

public class Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("O preço não pode ser negativo.");
        }

        Value = value;
    }
}