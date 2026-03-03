using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using Hypesoft.Domain.Entities;

namespace Hypesoft.Infrastructure.Mappings;

public class ProductMapping
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();

                map.MapIdMember(p => p.Id)
                    .SetSerializer(new StringSerializer(BsonType.String));
            });
        }
    }
}