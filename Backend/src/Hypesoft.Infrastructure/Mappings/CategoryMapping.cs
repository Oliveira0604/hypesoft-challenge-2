using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.ValueObjects.Category;

namespace Hypesoft.Infrastructure.Mappings;

public class CategoryMapping
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Category)))
        {
            BsonClassMap.RegisterClassMap<Category>(map =>
            {
                map.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.String));
                
                map.MapMember(c => c.Name)
                    .SetSerializer(new CategoryNameSerializer());
            });
        }
    }
}

// --- SERIALIZER PARA O VALUE OBJECTS ---

public class CategoryNameSerializer : SerializerBase<Name>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Name value) 
        => context.Writer.WriteString(value.Value);

    public override Name Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) 
        => new Name(context.Reader.ReadString());
}