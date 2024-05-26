using TodoList.Abstractions;

namespace TodoList.Models.Responses;

[Serializable]
public sealed record GetAllTodoQueryResponse(List<TodoDto> Todos): IResponse;