using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record UpdateTodoCommand(
    Guid UserId,
    Guid TodoId,
    string Title,
    string Description,
    DateTimeOffset ExecutionDate,
    bool IsCompleted) : ICommand<UpdateTodoCommandResponse>;