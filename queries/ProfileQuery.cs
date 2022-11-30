namespace hot_demo.queries;

public partial class Query
{
    [Authorize]
    public async Task<List<Profile>> GetProfiles([Service] Service service) =>
        await service.GetProfiles();
}