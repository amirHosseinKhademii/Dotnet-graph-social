using hot_demo.types;
using hot_demo.utils;
using MongoDB.Driver;

namespace hot_demo.services
{
    public partial class Service
    {
        public async Task<List<User>> GetUsersAsync() => await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> CreateUserAsync(string email, string password)
        {
            var enPassowrd = Encript.EncodePassword(password);
            var user = new User()
            {
                Email = email,
                Password = enPassowrd
            };

            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<string> SignInUserAsync(string email, string password)
        {
            var user = await _userCollection.Find(item => item.Email == email).FirstOrDefaultAsync();
            if (user == null) new UnauthorizedAccessException();
            return _jwtAuthentication.Authenticate(email);
        }
    }
}

