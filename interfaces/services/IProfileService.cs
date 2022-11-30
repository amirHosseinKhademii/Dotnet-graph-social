namespace hot_demo.interfaces.services;

public interface IProfileServcie
{
    public Task<List<Profile>> GetProfiles();
    public Task<Profile> CreateProfile(string userId);

    public Task<Profile> UpdateProfile(string id, int? age, Gender? gender);
}