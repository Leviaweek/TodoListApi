using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record LoginWebUserCommand(string Login, string Password): ICommand<LoginWebUserCommandResponse>;