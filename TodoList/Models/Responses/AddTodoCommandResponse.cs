using TodoList.Abstractions;

namespace TodoList.Models.Responses;

public sealed record AddTodoCommandResponse(TodoDto? Todo = null): IResponse;