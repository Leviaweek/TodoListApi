using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Models;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class DeleteTodoCommandHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : ICommandHandler<DeleteTodoCommand, DeleteTodoCommandResponse>
{
    public async ValueTask<DeleteTodoCommandResponse> HandleAsync(DeleteTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var todo = await db.Todos.FirstOrDefaultAsync(x => x.UserId == command.UserId && x.Id == command.TodoId,
            cancellationToken);
        if (todo is null || todo.IsDeleted)
            return new DeleteTodoCommandResponse(false);
        todo.IsDeleted = true;
        await db.SaveChangesAsync(cancellationToken);
        return new DeleteTodoCommandResponse(true);
    }
}