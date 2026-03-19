using System.Text.RegularExpressions;

namespace Hypesoft.Domain.ValueObjects.User;

public partial class UserPassword
{
    public string Value {get;}

    public UserPassword(string value)
    {
        if (!UserPasswordRegexValidator().IsMatch(value))
        {
            throw new Exception("A senha precisa ter pelo menos 1 caractere maiúsculo, 1 minúsculo e 1 número.");
        }

        Value = value;
    }

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex UserPasswordRegexValidator();
}