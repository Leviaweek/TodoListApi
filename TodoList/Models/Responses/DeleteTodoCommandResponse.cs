using TodoList.Abstractions;

namespace TodoList.Models.Responses;

public sealed record DeleteTodoCommandResponse(bool IsDeleted): IResponse;