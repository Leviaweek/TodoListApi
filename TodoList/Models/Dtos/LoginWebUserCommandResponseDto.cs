using System.Text.Json.Serialization;
using TodoList.Abstractions;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record LoginWebUserCommandResponseDto([property: JsonPropertyName("user")]WebUserDto User): IResponse;