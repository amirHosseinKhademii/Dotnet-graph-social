using hot_demo.entities;

namespace hot_demo.queries
{
    public class BookQuery
    {
        public Book GetBook() =>
            new Book
            {
                Title = "C# in depth.",
                Author = new Author
                {
                    Name = "Jon Skeet"
                }
            };
    }


}