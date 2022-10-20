using hot_demo.types;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace hot_demo.services;

public partial class Service
{
    private readonly IMongoCollection<User> _userCollection;
    private readonly IMongoCollection<Book> _booksCollection;
    private readonly IMongoCollection<Todo> _todosCollection;

    public Service(
        IOptions<MongoDBSetting> settings)
    {
        var mongoClient = new MongoClient(
            settings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            settings.Value.DatabaseName);

        _userCollection = mongoDatabase.GetCollection<User>("Users");
        _booksCollection = mongoDatabase.GetCollection<Book>("Books");
        _todosCollection = mongoDatabase.GetCollection<Todo>("Todos");
    }
}