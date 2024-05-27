using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

public sealed record AddTodoCommandResponse(TodoDto? Todo = null): IResponse;