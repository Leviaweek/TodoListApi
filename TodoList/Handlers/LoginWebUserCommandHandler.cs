using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Handlers;

public sealed class LoginWebUserCommandHandler(IDbContextFactory<TodoDbContext> dbContextFactory)
    : ICommandHandler<LoginWebUserCommand, LoginWebUserCommandResponse>
{
    public async ValueTask<LoginWebUserCommandResponse> HandleAsync(LoginWebUserCommand command,
        CancellationToken cancellationToken = default)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        var webUser = await db.WebUsers.Include(webUser => webUser.User)
            .FirstOrDefaultAsync(x => x.Login == command.Login &&
                                      x.Password == command.Password, cancellationToken);
        return webUser is null
            ? new LoginWebUserCommandResponse()
            : new LoginWebUserCommandResponse(webUser.ToDto(webUser.User.Name));
    }
}