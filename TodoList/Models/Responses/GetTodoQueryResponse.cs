using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

public sealed record GetTodoQueryResponse(TodoDto? Todo): IResponse;