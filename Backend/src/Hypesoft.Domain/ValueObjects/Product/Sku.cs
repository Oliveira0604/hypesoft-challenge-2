using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.Product;

public partial class Sku
{
    public string Value { get; }

    public Sku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("O SKU não pode ser vazio ou conter apenas espaços em branco.");
        }

        if (!SkuValidatorRegex().IsMatch(value))
        {
            throw new ArgumentException("O SKU deve seguir o formato 'AAA-1234', onde 'AAA' são letras maiúsculas e '1234' são dígitos. O SKU não pode conter caracteres especiais ou espaços.");
        }

        Value = value;
    }

    // O SKU deve seguir o formato "AAA-1234", onde "AAA" são letras maiúsculas e "1234" são dígitos. O SKU não pode conter caracteres especiais ou espaços.
    [GeneratedRegex(@"^[A-Z]{2}-\d{4}$")]
    private static partial Regex SkuValidatorRegex();
}