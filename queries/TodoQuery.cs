using hot_demo.types;
using HotChocolate.AspNetCore.Authorization;


namespace hot_demo.queries;


public partial class Query
{
    public async Task<List<Todo>> GetTodos([Service] IHttpContextAccessor httpContextAccessor)
    {
        Console.WriteLine(httpContextAccessor.HttpContext.Request.Headers.Authorization);
        return await _service.GetTodosAsync();
    }
}