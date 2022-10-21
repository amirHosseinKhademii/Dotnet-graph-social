using hot_demo.types;
using Microsoft.AspNetCore.Authorization;

namespace hot_demo.queries;

[Authorize]
public partial class Query
{
    [AllowAnonymous]
    public async Task<List<Todo>> GetTodos() => await _service.GetTodosAsync();
}