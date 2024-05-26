using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record UpdateTodoCommandResponseDto([property: JsonPropertyName("todo")]TodoDto Todo);