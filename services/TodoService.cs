
using hot_demo.interfaces.services;
using hot_demo.types;
using MongoDB.Driver;

namespace hot_demo.services;

public partial class Service : ITodoService
{
    public async Task<List<Todo>> GetTodosAsync(string userId) => await _todosCollection.Find(todo => todo.User==userId).ToListAsync();

    public async Task<Todo> CreateTodosAsync(string title,string userId, string? body)
    {

        var todo = new Todo()
        {
            Title = title,
            User = userId,
            Body = body
        };
        await _todosCollection.InsertOneAsync(todo);
        return todo;
    }
}