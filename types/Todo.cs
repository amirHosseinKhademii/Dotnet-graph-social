
namespace hot_demo.types;

using hot_demo.services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public record Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    public string Title { get; init; }

    public string? Body { get; init; }

    [GraphQLIgnore]
    public string? Author { get; init; }

    public async Task<User> GetUser([Service] Service service, [Parent] Todo todo) => await service.GetUserAsync(todo.Author);

}
