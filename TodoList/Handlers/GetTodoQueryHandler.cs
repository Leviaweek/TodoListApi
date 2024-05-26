using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Models.Queries;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class GetTodoQueryHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : IQueryHandler<GetTodoQuery, GetTodoQueryResponse>
{
    public async ValueTask<GetTodoQueryResponse> HandleAsync(GetTodoQuery query, CancellationToken cancellationToken)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var todo = await db.Todos.FirstOrDefaultAsync(x => 
                x.UserId == query.UserId &&
                x.Id == query.TodoId &&
                !x.IsDeleted,
            cancellationToken);
        return new GetTodoQueryResponse(todo?.ToDto());
    }
}