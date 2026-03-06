using Hypesoft.Domain.ValueObjects.Product;
namespace Hypesoft.Domain.Entities;

public class Product(Name name,Price price, Description description, Category category,  StockQuantity stockQuantity)
{
    public string Id { get; private set;} = Guid.NewGuid().ToString();
    public Name Name { get; private set; } = name;
    public Price Price { get; private set; } = price;
    public Description Description { get; private set; } = description;
    public Category Category { get; private set; } = category;
    public StockQuantity StockQuantity { get; private set; } = stockQuantity;

    public void UpdateName(string name)
    {
        Name = new Name(name);
    }

    public void UpdatePrice(decimal price)
    {
        Price = new Price(price);
    }

    public void UpdateDescription(string description)
    {
        Description = new Description(description);
    }

    public void UpdateCategory(string category)
    {
        Category = new Category(category);
    }

    public void UpdateStockQuantity(int stockQuantity)
    {
        StockQuantity = new StockQuantity(stockQuantity);
    }
    
}