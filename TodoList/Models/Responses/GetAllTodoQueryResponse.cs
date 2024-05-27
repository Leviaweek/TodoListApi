using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

[Serializable]
public sealed record GetAllTodoQueryResponse(List<TodoDto> Todos): IResponse;