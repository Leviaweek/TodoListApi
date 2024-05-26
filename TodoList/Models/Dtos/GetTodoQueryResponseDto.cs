using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record GetTodoQueryResponseDto(
    [property: JsonPropertyName("todo")]TodoDto TodoDto);