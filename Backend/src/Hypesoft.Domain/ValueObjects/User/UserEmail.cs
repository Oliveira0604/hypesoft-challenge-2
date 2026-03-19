using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.User;

public partial class UserEmail
{
    public string Value {get;}

    public UserEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception("O email não pode ser vázio.");
        }

        if (!UserEmailRegexValidator().IsMatch(value))
        {
            throw new Exception("Email inválido.");
        }

        Value = value;
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex UserEmailRegexValidator();
}