namespace Hypesoft.Domain.ValueObjects.Product;

public class Description
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A descrição não pode ser vazia ou conter apenas espaços em branco.");
        }

        if (value.Length < 10 || value.Length > 1000)
        {
            throw new ArgumentException("A descrição deve ter entre 10 e 1000 caracteres.");
        }

        Value = value;
    }
}