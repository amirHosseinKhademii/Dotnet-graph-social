
using hot_demo.types;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace hot_demo.services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BookService(
         IOptions<MongoDBSetting> repo)
        {
            var mongoClient = new MongoClient(
                repo.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                repo.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                repo.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetAsync() =>
     await _booksCollection.Find(_ => true).ToListAsync();


        // public Book GetBook(Guid id) => _repo.books.FirstOrDefault(item => item.Id == id);

        // public IEnumerable<Book> GetBooks() => _repo.books;

        // public Book CreateBook(string title)
        // {
        //     var author = new Author("test");
        //     var book = new Book(Guid.NewGuid(), title, author);
        //     _repo.books.Add(book);
        //     return book;
        // }

        // public Guid DeleteBook(Guid id)
        // {
        //     _repo.books.RemoveAll(item => item.Id != id);
        //     return id;
        // }


    }
}