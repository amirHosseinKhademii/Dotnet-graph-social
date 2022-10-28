using System;
namespace hot_demo.services;

public partial class Service : ITodoService
{
    public async Task<List<Todo>> GetTodosAsync(string userId) => await _todosCollection.Find(todo => todo.Author == userId).ToListAsync();

    public async Task<Todo> CreateTodosAsync(string title, string userId, string? body)
    {

        var todo = new Todo()
        {
            Title = title,
            Author = userId,
            Body = body,
            CreatedDate = new DateTime(),
            IsCompleted = false,
        };
        await _todosCollection.InsertOneAsync(todo);
        return todo;
    }

    public async Task<string> RemoveTodoAsync(string todoId)
    {
        await _todosCollection.DeleteOneAsync(todo => todo.Id == todoId);
        return todoId;
    }

}