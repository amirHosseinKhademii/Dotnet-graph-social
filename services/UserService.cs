using hot_demo.types;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace hot_demo.services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserService(
         IOptions<MongoDBSetting> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAsync() => await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> CreateAsync(string email ,string password)
        {
            var user = new User()
            {
                Email = email,
                Password = password
            };
            await _userCollection.InsertOneAsync(user);
            return user;
        }
    }
}

