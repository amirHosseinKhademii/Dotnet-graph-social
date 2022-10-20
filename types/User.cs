using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace hot_demo.types
{
    public record User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }
    }
}