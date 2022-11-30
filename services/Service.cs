namespace hot_demo.services;

public partial class Service
{
    private readonly IJwtAuthentication _jwtAuthentication;
    private readonly IMongoCollection<User> _userCollection;
    private readonly IMongoCollection<Book> _booksCollection;
    private readonly IMongoCollection<Todo> _todosCollection;

    private readonly IMongoCollection<Profile> _profileCollection;

    public Service(
        IOptions<MongoDBSetting> settings, IJwtAuthentication JwtAuthentication)
    {
        _jwtAuthentication = JwtAuthentication;
        var mongoClient = new MongoClient(
            settings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            settings.Value.DatabaseName);

        _userCollection = mongoDatabase.GetCollection<User>("Users");
        _booksCollection = mongoDatabase.GetCollection<Book>("Books");
        _todosCollection = mongoDatabase.GetCollection<Todo>("Todos");
        _profileCollection = mongoDatabase.GetCollection<Profile>("Profiles");
    }
}