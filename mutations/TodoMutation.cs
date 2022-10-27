namespace hot_demo.mutations;

[Authorize]
public partial class Mutation
{
    public async Task<Todo> CreateTodo([Service] Service service, [Service] ITopicEventSender sender, ClaimsPrincipal claimsPrincipal, string title,
        string? body)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        var todo = await service.CreateTodosAsync(title, userId, body);
        await sender.SendAsync("TodoAdded", todo);
        return todo;
    }

    public async Task<string> RemoveTodo([Service] Service service, string id) => await service.RemoveTodoAsync(id);
}