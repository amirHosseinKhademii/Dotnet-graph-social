using hot_demo.services;
using hot_demo.types;

namespace hot_demo.queries
{
    [ExtendObjectType("Query")]
    public class UserQuery
    {
        private readonly UserService _service;
        public UserQuery(UserService service)
        {
            _service = service;

        }

        public async Task<List<User>> GetUsers() => await _service.GetAsync();
    }
}