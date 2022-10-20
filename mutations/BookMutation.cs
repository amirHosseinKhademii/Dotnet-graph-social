using hot_demo.services;
using hot_demo.types;


namespace hot_demo.mutations
{
    [ExtendObjectType("Mutation")]
    public class BookMutation
    {
        private readonly BookService _service;
        public BookMutation(BookService service)
        {
            _service = service;

        }

        public async Task<Book> CreateBook(string title) => await _service.CreateAsync(title);

        public async Task<string> DeleteBook(string id) => await _service.RemoveAsync(id);

        public async Task<Book> UpdateBook(Book book) => await _service.UpdateAsync(book);

        public async Task<string> UpdateAuthor(string id, string author) => await _service.UpdateAuthorAsync(id, author);
    }
}