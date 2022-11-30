namespace hot_demo.interfaces.services;

public interface IProfileServcie
{
    public Task<List<Profile>> GetProfiles();
    public Task<Profile> CreateProfile(string userId);
}