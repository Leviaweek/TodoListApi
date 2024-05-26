using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

public sealed record DeleteTodoCommandDto([property: JsonPropertyName("id")]Guid TodoId);