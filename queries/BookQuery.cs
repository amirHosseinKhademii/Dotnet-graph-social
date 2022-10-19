


using hot_demo.services;
using hot_demo.types;

namespace hot_demo.queries
{
    public class BookQuery
    {
        private readonly BookService _service;
        public BookQuery(BookService service)
        {
            _service = service;

        }

        // public Book GetBook(Guid id) =>
        //   _service.GetBook(id);

        public async Task<List<Book>> GetBooks() =>
         await _service.GetAsync();

    }

}