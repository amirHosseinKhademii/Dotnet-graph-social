
using hot_demo.types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace hot_demo.services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BookService(
         IOptions<MongoDBSetting> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

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

        public async Task<string> RemoveAsync(string id)
        {
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
            return id;
        }

        public async Task<Book> UpdateAsync(Book book)
        {

            await _booksCollection.ReplaceOneAsync(x => x.Id == book.Id, book);
            return book;
        }

        public async Task<string> UpdateAuthorAsync(string id, string name)
        {
            var author = new Author() { Name = name };
            var update = Builders<Book>.Update.Set(book => book.Author, author);
            var filter = Builders<Book>.Filter.Where(item => item.Id == id);
            await _booksCollection.UpdateOneAsync(filter, update);
            return id;
        }
    }
}
