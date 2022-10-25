using System.Security.Claims;
using hot_demo.types;
using HotChocolate.AspNetCore.Authorization;


namespace hot_demo.queries;

[Authorize]
public partial class Query
{
    public async Task<List<Todo>> GetTodos(ClaimsPrincipal claimsPrincipal,[Service] IHttpContextAccessor httpContextAccessor)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _service.GetTodosAsync();
    }
}