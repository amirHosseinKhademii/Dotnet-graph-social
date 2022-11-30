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

        public async Task<Profile> UpdateProfile(string id, int? age, Gender? gender)
        {
            var updateAge = Builders<Profile>.Update.Set(profile => profile.Age, age);
            var updateGender = Builders<Profile>.Update.Set(profile => profile.Gender, gender);
            var update = Builders<Profile>.Update.Combine(updateAge, updateGender);
            var filter = Builders<Profile>.Filter.Where(item => item.Id == id);
            var profile = await _profileCollection.FindOneAndUpdateAsync(filter, update);
            profile.Age = age;
            profile.Gender = gender;
            return profile;

        }
    }
}

