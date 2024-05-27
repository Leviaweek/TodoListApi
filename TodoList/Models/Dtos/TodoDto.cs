using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

public sealed record TodoDto(
    [property: JsonPropertyName("id")]Guid Id,
    [property: JsonPropertyName("title")]string Title,
    [property: JsonPropertyName("description")]string Description,
    [property: JsonPropertyName("isCompleted")]bool IsCompleted,
    [property: JsonPropertyName("executionDate")]DateTimeOffset ExecutionDate,
    [property: JsonPropertyName("createdAt")]DateTimeOffset CreatedAt);