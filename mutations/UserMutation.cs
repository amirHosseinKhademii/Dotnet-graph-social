
using hot_demo.types;


namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<User> CreateBook(string email, string password) =>
            await _userService.CreateAsync(email, password);
    }
}