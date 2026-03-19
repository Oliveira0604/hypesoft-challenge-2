using Hypesoft.Domain.ValueObjects.Category;
using Hypesoft.Domain.ValueObjects.User;

namespace Hypesoft.Domain.Entities;

public class User(UserName userName, UserEmail userEmail, UserCellphone userCellphone, UserPassword userPassword)
{
    public UserName UserName {get; set;} = userName;
    public UserEmail UserEmail {get; set;} = userEmail;
    public UserCellphone UserCellphone {get; set;} = userCellphone;
    public UserPassword UserPassword {get; set;} = userPassword;

    public void UpdateUserName(string name)
    {
        UserName = new UserName(name);
    }

    public void UpdateUserEmail(string email)
    {
        UserEmail = new UserEmail(email);
    }

    public void UpdateUserCellphone(string cellphone)
    {
        UserCellphone = new UserCellphone(cellphone);
    }

    public void UpdateUserPassword(string password)
    {
        UserPassword = new UserPassword(password);
    }
}