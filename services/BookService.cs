using hot_demo.repositories;
using hot_demo.types;


namespace hot_demo.services
{
    public class BookService
    {
        private readonly BookRepository _repo;
        public BookService(BookRepository repo)
        {
            _repo = repo;

        }

        public Book GetBook(Guid id) => _repo.books.FirstOrDefault(item => item.Id == id);

        public IEnumerable<Book> GetBooks() => _repo.books;

        public Book CreateBook(string title)
        {
            var author = new Author("test");
            var book = new Book(Guid.NewGuid(), title, author);
            _repo.books.Add(book);
            return book;
        }

    }
}