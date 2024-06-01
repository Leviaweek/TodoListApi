using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Models.Queries;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class GetAllTodoQueryHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : IQueryHandler<GetAllTodoQuery, GetAllTodoQueryResponse>
{
    public async ValueTask<GetAllTodoQueryResponse> HandleAsync(GetAllTodoQuery query,
        CancellationToken cancellationToken = default)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var todos = db.Todos.Where(x => x.UserId == query.UserId && !x.IsDeleted)
            .OrderByDescending(x => !x.IsCompleted)
            .ThenBy(x => x.DeadLine < DateTimeOffset.UtcNow)
            .ThenByDescending(x => x.DeadLine);
        return new GetAllTodoQueryResponse(await todos.Select(x => x.ToDto())
            .ToListAsync(cancellationToken: cancellationToken));
    }
}