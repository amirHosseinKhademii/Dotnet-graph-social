using hot_demo.types;

namespace hot_demo.interfaces.services;

public interface ITodoService
{
    public Task<List<Todo>> GetTodosAsync(string userId);
}