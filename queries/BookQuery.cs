


using hot_demo.services;
using hot_demo.types;

namespace hot_demo.queries
{
    [ExtendObjectType("Query")]
    public class BookQuery
    {
        private readonly BookService _service;
        public BookQuery(BookService service)
        {
            _service = service;

        }

        public async Task<Book> GetBook(string id) =>
         await _service.GetByIdAsync(id);

        public async Task<List<Book>> GetBooks() =>
         await _service.GetAsync();

    }

}