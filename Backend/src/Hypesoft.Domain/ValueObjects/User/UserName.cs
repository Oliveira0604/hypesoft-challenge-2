using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.User;

public partial class UserName
{
    public string Value {get;}

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception("O nome não pode ser vázio.");
        }

        if (!UserNameRegexValidator().IsMatch(value))
        {
            throw new Exception("O nome não segue os padrões. (Apenas letras e espaços. Iniciando com letra.)");
        }

        if (value.Length < 3 || value.Length > 100)
        {
            throw new Exception("O nome não pode ser menor que 3 nem maior que 100 caracteres.");
        }

        Value = value;
    }
    [GeneratedRegex(@"^[a-zA-ZÀ-ÿ]{3}[a-zA-ZÀ-ÿ\s]*$")]
    private static partial Regex UserNameRegexValidator();
}