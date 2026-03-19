using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.User;

public partial class UserCellphone
{
    public string Value {get;}

    public UserCellphone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception("O número de celular não pode ser vázio.");
        }

        if (!UserCellphoneRegexValidator().IsMatch(value))
        {
            throw new Exception("O número é inválido.");
        }

        if (value.Length != 11)
        {
            throw new Exception("O número não pode ser diferente de 11 caracteres.");
        }

        Value = value;
    }
    [GeneratedRegex((@"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$"))]
    private static partial Regex UserCellphoneRegexValidator();
}