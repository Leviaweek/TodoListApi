namespace TodoList.Models;

public sealed record TodoDto(
    Guid Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTimeOffset ExecutionDate,
    DateTimeOffset CreatedAt);