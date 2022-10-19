

using hot_demo.types;

namespace hot_demo.queries
{

    public class BookQuery
    {
        Book book = new Book(1,
           "C# in depth.",
                new Author("Jon Skeet")
               );

        IEnumerable<Book> books = new List<Book>() { new Book(1,
           "C# in depth.",
                new Author("Jon Skeet")
               ),
               new Book(2,
           "D# in depth.",
                new Author("Jon Amir")
               ) };
        public Book GetBook(int id) =>
          books.FirstOrDefault(item => item.Id == id);

        public IEnumerable<Book> GetBooks() =>
          books;

    }

}