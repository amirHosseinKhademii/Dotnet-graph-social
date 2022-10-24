using hot_demo.types;


namespace hot_demo.queries;

public partial class Query
{
    public async Task<List<Todo>> GetTodos() => await _service.GetTodosAsync();
}