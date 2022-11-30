

namespace hot_demo.interfaces.services;

public interface IUserService
{
    public Task<List<User>> GetUsersAsync();

    public Task<User> CreateUserAsync(string email, string password);

    public Task<string> SignInUserAsync(string email, string password);
}