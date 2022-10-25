
namespace hot_demo.types;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public record Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    public string Title { get; init; }

    public string? Body { get; init; }

    public string? User { get; init; }
}
