using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record UpdateTodoCommandDto(
    [property: JsonPropertyName("todoId")]Guid TodoId,
    [property: JsonPropertyName("title")]string Title,
    [property: JsonPropertyName("description")]string Description,
    [property: JsonPropertyName("executionTime")]DateTimeOffset ExecutionTime,
    [property: JsonPropertyName("isCompleted")]bool IsCompleted);