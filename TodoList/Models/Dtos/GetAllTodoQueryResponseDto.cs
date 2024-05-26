using System.Text.Json.Serialization;
using TodoList.Abstractions;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record GetAllTodoQueryResponseDto([property: JsonPropertyName("todos")]List<TodoDto> Todos): IResponse;