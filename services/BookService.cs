using hot_demo.repositories;
using hot_demo.types;

namespace hot_demo.services
{
    public class BookService
    {
        private readonly BookRepository repo;
        public BookService(BookRepository repo)
        {
            this.repo = repo;

        }

        public Book GetBook(int id) => repo.books.FirstOrDefault(item => item.Id == id);

        public IEnumerable<Book> GetBooks() => repo.books;

    }
}