using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.Product;

public partial class CategoryName
{
    public string Value { get; }

    public CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A categoria não pode ser vazio ou conter apenas espaços em branco.");
        }

        if (!CategoryValidatorRegex().IsMatch(value))
        {
            throw new ArgumentException("A categoria deve seguir o formato padrão: apenas letras (incluindo acentos) e espaços, com comprimento entre 5 e 30 caracteres.");
        }

        Value = value;
    }

    [GeneratedRegex(@"^[a-zA-ZÀ-ÿ\s]{5,30}$")]
    private static partial Regex CategoryValidatorRegex();
}