
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace hot_demo.types;

public record Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Title { get; set; }

    public Author? Author { get; set; }

}

public record Author
{
    public string Name { get; set; }
}