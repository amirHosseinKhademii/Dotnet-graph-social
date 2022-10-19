

using hot_demo.repositories;
using hot_demo.types;

namespace hot_demo.queries
{
    public class BookQuery
    {
        private readonly BookRepository repo;
        public BookQuery(BookRepository repo)
        {
            this.repo = repo;

        }

        public Book GetBook(int id) =>
          repo.books.FirstOrDefault(item => item.Id == id);

        public IEnumerable<Book> GetBooks() =>
          repo.books;

    }

}