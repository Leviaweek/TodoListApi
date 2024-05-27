using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Database.Models;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class AddWebUserCommandHandler(
    IDbContextFactory<TodoDbContext> dbContextFactory) : ICommandHandler<AddWebUserCommand, AddWebUserCommandResponse>
{
    public async ValueTask<AddWebUserCommandResponse> HandleAsync(AddWebUserCommand command,
        CancellationToken cancellationToken = default)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var existsWebUser = await db.WebUsers.AnyAsync(x => x.Login == command.Login,
            cancellationToken: cancellationToken);
        if (existsWebUser) return new AddWebUserCommandResponse();
        var user = new User
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
            Name = command.Name
        };
        var webUser = new WebUser
        {
            UserId = user.Id,
            CreatedAt = DateTimeOffset.UtcNow,
            Login = command.Login,
            User = user,
            Password = command.Password
        };
        await db.Users.AddAsync(user, cancellationToken);
        await db.WebUsers.AddAsync(webUser, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return new AddWebUserCommandResponse(webUser.ToDto(user.Name));
    }
}