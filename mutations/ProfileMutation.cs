namespace hot_demo.mutations;

[Authorize]
public partial class Mutation
{
    public async Task<Profile> CreateProfile([Service] Service service, [Service] ITopicEventSender sender, ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        return await service.CreateProfile(userId);
    }

    public async Task<Profile> UpdateProfile([Service] Service serivce, string id, int? age, Gender? gender) => await serivce.UpdateProfile(id, age, gender);
}
