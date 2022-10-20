using hot_demo.types;
using MongoDB.Driver;

namespace hot_demo.services;

public partial class Service
{
    public async Task<List<Todo>> GetTodosAsync() => await _todosCollection.Find(_ => true).ToListAsync();
}