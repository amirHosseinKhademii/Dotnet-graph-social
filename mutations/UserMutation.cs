using hot_demo.services;
using hot_demo.types;


namespace hot_demo.mutations
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        private readonly UserService _service;
        public UserMutation(UserService service)
        {
            _service = service;

        }

        public async Task<User> CreateBook(string email,string password) => await _service.CreateAsync(email,password);


    }
}