namespace hot_demo.queries
{
    public partial class Query
    {
        public async Task<List<User>> GetUsers([Service] Service service) => await service.GetUsersAsync();

        public async Task<User> GetUser([Service] Service service, [Parent] Todo todo) => await service.GetUserAsync(todo.Author);
    }
}