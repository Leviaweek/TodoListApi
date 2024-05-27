using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

public sealed record UpdateTodoCommandResponse(TodoDto? Todo = null): IResponse;