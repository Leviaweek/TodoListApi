using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record DeleteTodoCommand(Guid UserId, Guid TodoId): ICommand<DeleteTodoCommandResponse>;