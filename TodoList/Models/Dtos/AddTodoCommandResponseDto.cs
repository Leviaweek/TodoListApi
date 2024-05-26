using System.Text.Json.Serialization;
using TodoList.Abstractions;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record AddTodoCommandResponseDto([property: JsonPropertyName("todo")]TodoDto Todo): IResponse;