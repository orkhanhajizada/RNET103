using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoExample.Entities;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonRepresentation(BsonType.String)] 
    public string Name { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Date { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}