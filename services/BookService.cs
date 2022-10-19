
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

            _booksCollection = mongoDatabase.GetCollection<Book>("Books");
        }

        public async Task<List<Book>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetByIdAsync(string id) =>
            await _booksCollection.Find(item => item.Id == id).FirstOrDefaultAsync();


        public async Task<Book> CreateAsync(string title)
        {

            var book = new Book()
            {
                Title = title
            };
            await _booksCollection.InsertOneAsync(book);
            return book;

        }

        // public Guid DeleteBook(Guid id)
        // {
        //     _repo.books.RemoveAll(item => item.Id != id);
        //     return id;
        // }


    }
}