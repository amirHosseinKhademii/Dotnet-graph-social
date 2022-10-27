using System.Security.Claims;
using hot_demo.services;
using hot_demo.types;
using HotChocolate.AspNetCore.Authorization;

namespace hot_demo.mutations;

[Authorize]
public partial class Mutation
{
    public async Task<Todo> CreateTodo([Service] Service service, ClaimsPrincipal claimsPrincipal, string title,
        string? body)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        return await service.CreateTodosAsync(title, userId, body);
    }

    public async Task<string> RemoveTodo([Service] Service service, string id) => await service.RemoveTodoAsync(id);
}