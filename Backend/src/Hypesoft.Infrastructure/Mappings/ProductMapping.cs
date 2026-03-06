using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.ValueObjects.Product;

namespace Hypesoft.Infrastructure.Mappings;

public class ProductMapping
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {

                map.MapIdMember(p => p.Id)
                    .SetSerializer(new StringSerializer(BsonType.String));

                map.MapMember(p => p.Name)
                .SetSerializer(new NameSerializer());

                map.MapMember(p => p.Price)
                .SetSerializer(new PriceSerializer());
                map.MapMember(p => p.Description)
                .SetSerializer(new DescriptionSerializer());
                map.MapMember(p => p.Category)
                .SetSerializer(new CategorySerializer());
                map.MapMember(p => p.StockQuantity)
                .SetSerializer(new StockQuantitySerializer());
            });
        }
    }
}

// --- SERIALIZERS PARA OS VALUE OBJECTS ---

public class NameSerializer : SerializerBase<Name>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Name value) 
        => context.Writer.WriteString(value.Value);

    public override Name Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new Name(context.Reader.ReadString());
}

public class DescriptionSerializer : SerializerBase<Description>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Description value) 
        => context.Writer.WriteString(value.Value);

    public override Description Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new Description(context.Reader.ReadString());
}

public class CategorySerializer : SerializerBase<Category>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Category value) 
        => context.Writer.WriteString(value.Value);

    public override Category Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new Category(context.Reader.ReadString());
}

public class PriceSerializer : SerializerBase<Price>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Price value) 
        => context.Writer.WriteDecimal128(value.Value);

    public override Price Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new Price((decimal)context.Reader.ReadDecimal128());
}

public class StockQuantitySerializer : SerializerBase<StockQuantity>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, StockQuantity value) 
        => context.Writer.WriteInt32(value.Value);

    public override StockQuantity Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new StockQuantity(context.Reader.ReadInt32());
}