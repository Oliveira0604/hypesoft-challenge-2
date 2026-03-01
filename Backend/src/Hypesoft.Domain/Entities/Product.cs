namespace Hypesoft.Domain.Entities;

public class Product
{
    public string Id { get; private set;} = Guid.NewGuid().ToString();
    public Name Name { get; private set;} = name;
    public Price Price { get; private set;} = price;
    public Description Description { get; private set;} = description;
    public Sku Sku { get; private set;} = sku;
    public StockQuantity StockQuantity { get; private set;} = stockQuantity;


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

    public void UpdateSku(string sku)
    {
        Sku = new Sku(sku);
    }

    public void UpdateStockQuantity(int stockQuantity)
    {
        StockQuantity = new StockQuantity(stockQuantity);
    }
    
}