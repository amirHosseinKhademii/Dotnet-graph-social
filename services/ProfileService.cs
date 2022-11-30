namespace hot_demo.services
{
    public partial class Service : IProfileServcie
    {
        public async Task<List<Profile>> GetProfiles() => await _profileCollection.Find(_ => true).ToListAsync();
        public async Task<Profile> CreateProfile(string userId)
        {
            var profile = new Profile() { UserId = userId };
            await _profileCollection.InsertOneAsync(profile);
            return profile;
        }
    }
}

