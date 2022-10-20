
using hot_demo.types;


namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<User> CreateUser(string email, string password) =>
            await _service.CreateUserAsync(email, password);
    }
}