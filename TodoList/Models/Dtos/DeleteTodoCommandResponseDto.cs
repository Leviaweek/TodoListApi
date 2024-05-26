using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

public sealed record DeleteTodoCommandResponseDto([property: JsonPropertyName("isDeleted")]bool IsDeleted);