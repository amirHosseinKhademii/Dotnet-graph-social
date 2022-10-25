using System.Security.Claims;
using hot_demo.types;
using HotChocolate.AspNetCore.Authorization;

namespace hot_demo.mutations;

[Authorize]
public partial class Mutation
{
    public async Task<Todo> CreateTodo(ClaimsPrincipal claimsPrincipal, string title, string? body)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _service.CreateTodosAsync(title, userId, body);
    }
}