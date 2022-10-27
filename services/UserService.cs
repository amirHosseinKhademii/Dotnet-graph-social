namespace hot_demo.services
{
    public partial class Service : IUserService
    {
        public async Task<List<User>> GetUsersAsync() => await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> GetUserAsync(string id) => await _userCollection.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task<User> CreateUserAsync(string email, string password)
        {
            var user = new User()
            {
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<string> SignInUserAsync(string email, string password)
        {
            var user = await _userCollection.Find(item => item.Email == email).FirstOrDefaultAsync();
            var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (user == null || !isValid) return null;
            return _jwtAuthentication.Authenticate(user.Id, email);
        }
    }
}

