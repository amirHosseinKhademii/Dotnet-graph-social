
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace hot_demo.types;

public record Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    public string Title { get; init; }

    public Author? Author { get; init; }
}

public record Author
{
    public string Name { get; init; }
}