namespace hot_demo.mutations;

[Authorize]
public partial class Mutation
{
    public async Task<Profile> CreateProfile([Service] Service service, [Service] ITopicEventSender sender, ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        return await service.CreateProfile(userId);
    }
}
