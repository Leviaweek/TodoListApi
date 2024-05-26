using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record AddTodoCommandDto(
    [property: JsonPropertyName("title")]string Title,
    [property: JsonPropertyName("description")]string Description,
    [property: JsonPropertyName("executionDate")]DateTimeOffset ExecutionTime);