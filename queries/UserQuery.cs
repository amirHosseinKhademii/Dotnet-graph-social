
using hot_demo.types;

namespace hot_demo.queries
{
    public partial class Query
    {
        public async Task<List<User>> GetUsers() => await _userService.GetAsync();
    }
}