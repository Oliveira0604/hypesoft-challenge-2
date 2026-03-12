using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.Category;

public partial class Name
{
    public string Value {get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A descrição não pode ser vazia ou conter apenas espaços em branco.");
        }

        if (!NameValidatorRegex().IsMatch(value))
        {
            throw new Exception("O nome não pode conter símbolos ou espaços.");
        }

        if(value.Length < 5 || value.Length > 20)
        {
            throw new Exception("O produto não pode ter menos de 5 caracteres e nem mais de 20.");
        }

        Value = value;
    }

    [GeneratedRegex(@"^[a-zA-ZÀ-ÿ]+$")]
    private static partial Regex NameValidatorRegex();
}