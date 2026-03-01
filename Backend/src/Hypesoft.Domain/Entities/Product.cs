namespace Hypesoft.Domain.Entities;

public class Product
{
    public string Id { get; private set;}
    public Name Name { get; private set;}
    public Price Price { get; private set;}
    public Description Description { get; private set;}
    public Sku Sku { get; private set;}

}