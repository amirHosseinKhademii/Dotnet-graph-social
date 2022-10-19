


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

        public Book GetBook(int id) =>
          _service.GetBook(id);

        public IEnumerable<Book> GetBooks() =>
         _service.GetBooks();

    }

}