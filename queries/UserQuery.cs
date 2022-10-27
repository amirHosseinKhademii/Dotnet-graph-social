using hot_demo.services;
using hot_demo.types;

namespace hot_demo.queries
{
    public partial class Query
    {
        public async Task<List<User>> GetUsers([Service] Service service) => await service.GetUsersAsync();
    }
}