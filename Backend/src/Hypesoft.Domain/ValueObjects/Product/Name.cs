using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.Product;


public partial class Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("O nome não pode ser vazio ou conter apenas espaços em branco.");
        }

        if (!NameValidatorRegex().IsMatch(value))
        {
            throw new ArgumentException("O nome contém caracteres inválidos. Ele deve iniciar com uma letra ou número e pode conter letras, números, espaços, hífens, sublinhados, pontos, parênteses ou barras.");
        }

        if (value.Length < 3 || value.Length > 100)
        {
            throw new ArgumentException("O nome deve ter entre 3 e 100 caracteres.");
        }

        Value = value;
    }

    // O nome deve iniciar com uma letra ou número, seguido por letras, números, espaços, hífens, sublinhados, pontos, parênteses ou barras. O nome não pode conter caracteres especiais como @, #, $, etc.
    [GeneratedRegex(@"^[A-Za-z0-9À-ÿ][A-Za-z0-9À-ÿ\s\-_.\(\)\/]*$")]
    private static partial Regex NameValidatorRegex();
}