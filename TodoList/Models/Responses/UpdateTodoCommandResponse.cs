using TodoList.Abstractions;

namespace TodoList.Models.Responses;

public sealed record UpdateTodoCommandResponse(TodoDto? Todo = null): IResponse;