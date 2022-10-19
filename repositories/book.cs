using hot_demo.types;

namespace hot_demo.repositories
{
    public class BookRepository
    {
        public IEnumerable<Book> books = new List<Book>() { new Book(1,
           "C# in depth.",
                new Author("Jon Skeet")
               ),
               new Book(2,
           "D# in depth.",
                new Author("Jon Amir")
               ) };
    }
}