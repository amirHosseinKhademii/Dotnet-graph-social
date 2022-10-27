namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<User> CreateUser([Service] Service service, string email, string password) =>
            await service.CreateUserAsync(email, password);

        public async Task<string> SignInUser([Service] Service service, string email, string password) =>
            await service.SignInUserAsync(email, password);
    }
}