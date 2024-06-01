using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Database.Models;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class AddTodoCommandHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : ICommandHandler<AddTodoCommand, AddTodoCommandResponse>
{
    public async ValueTask<AddTodoCommandResponse> HandleAsync(AddTodoCommand command,
        CancellationToken cancellationToken = default)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == command.UserId, cancellationToken);
        if (user is null) return new AddTodoCommandResponse();
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
            DeadLine = command.DeadLine,
            IsCompleted = false,
            Description = command.Description,
            Title = command.Title,
            UserId = user.Id,
            IsDeleted = false,
            User = user
        };
        await db.Todos.AddAsync(todo, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return new AddTodoCommandResponse(todo.ToDto());
    }
}