using System.Security.Claims;
using hot_demo.types;
using HotChocolate.AspNetCore.Authorization;


namespace hot_demo.queries;

[Authorize]
public partial class Query
{
    public async Task<List<Todo>> GetTodos(ClaimsPrincipal claimsPrincipal) =>
        await _service.GetTodosAsync(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
}