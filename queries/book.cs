

using hot_demo.types;

namespace hot_demo.queries
{

    public class BookQuery
    {
        Book book = new Book(1,
           "C# in depth.",
                new Author("Jon Skeet")
               );
        public Book GetBook() =>
          book;

        public IEnumerable<Book> GetBooks() =>
            new List<Book>() { book };

    }

}