using System.Text.Json.Serialization;
using TodoList.Database.Models;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record AddWebUserCommandResponseDto([property: JsonPropertyName("user")]WebUserDto User);