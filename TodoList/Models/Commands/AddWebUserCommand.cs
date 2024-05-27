using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record AddWebUserCommand(
    string Login,
    string Name,
    string Password): ICommand<AddWebUserCommandResponse>;