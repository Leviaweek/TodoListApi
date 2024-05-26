using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record AddTodoCommand(Guid UserId,
    string Title,
    string Description,
    DateTimeOffset ExecutionDate) : ICommand<AddTodoCommandResponse>;