
public record Profile
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }


    public int? Age { get; set; }

    public Gender? Gender { get; set; }

    [GraphQLIgnore]
    public string UserId { get; init; }

    public async Task<User> GetUser([Service] Service service, [Parent] Profile profile) => await service.GetUserAsync(profile.UserId);
}

public enum Gender
{
    Male,
    Female
}