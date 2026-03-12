using Hypesoft.Domain.ValueObjects.Category;

namespace Hypesoft.Domain.Entities;

public class Category(Name name)
{
    public string Id { get; private set;} = Guid.NewGuid().ToString();
    public Name Name {get; private set;} = name;

    public void UpdateName(string name)
    {
        Name = new Name(name);
    }
}