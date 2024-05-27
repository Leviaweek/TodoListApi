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
        var (userId, todoDto) = command;
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var todo = await db.Todos.FirstOrDefaultAsync(
            x => x.UserId == userId &&
                 x.Id == todoDto.Id &&
                 !x.IsDeleted, cancellationToken);
        if (todo is null)
            return new UpdateTodoCommandResponse();
        todo.ExecutionDate = todoDto.ExecutionDate;
        todo.IsCompleted = todoDto.IsCompleted;
        todo.Title = todoDto.Title;
        todo.Description = todoDto.Description;
        await db.SaveChangesAsync(cancellationToken);
        return new UpdateTodoCommandResponse(todo.ToDto());
    }
}