public record Profile
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }

    [GraphQLIgnore]
    public string UserId { get; init; }

    public async Task<User> GetUser([Service] Service service, [Parent] Profile profile) => await service.GetUserAsync(profile.UserId);
}