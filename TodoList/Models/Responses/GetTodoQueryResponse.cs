using TodoList.Abstractions;

namespace TodoList.Models.Responses;

public sealed record GetTodoQueryResponse(TodoDto? Todo): IResponse;