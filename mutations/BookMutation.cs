using hot_demo.services;
using hot_demo.types;


namespace hot_demo.mutations
{
    public class BookMutation
    {
        private readonly BookService _service;
        public BookMutation(BookService service)
        {
            _service = service;

        }

        public async Task<Book> CreateBook(string title) => await _service.CreateAsync(title);

        // public Guid DeleteBook(Guid id) => _service.DeleteBook(id);
    }
}