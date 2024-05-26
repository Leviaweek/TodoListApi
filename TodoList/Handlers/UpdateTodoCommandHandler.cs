using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class UpdateTodoCommandHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : ICommandHandler<UpdateTodoCommand, UpdateTodoCommandResponse>
{
    public async ValueTask<UpdateTodoCommandResponse> HandleAsync(UpdateTodoCommand command,
        CancellationToken cancellationToken)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var todo = await db.Todos.FirstOrDefaultAsync(
            x => x.UserId == command.UserId &&
                 x.Id ==  command.TodoId, cancellationToken);
        if (todo is null)
            return new UpdateTodoCommandResponse();
        todo.ExecutionDate = command.ExecutionDate;
        todo.IsCompleted = command.IsCompleted;
        todo.Title = command.Title;
        todo.Description = command.Description;
        await db.SaveChangesAsync(cancellationToken);
        return new UpdateTodoCommandResponse(todo.ToDto());
    }
}