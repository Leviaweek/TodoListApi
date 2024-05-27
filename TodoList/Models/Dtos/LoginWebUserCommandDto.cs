using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record LoginWebUserCommandDto(
    [property: JsonPropertyName("login")]string Login,
    [property: JsonPropertyName("password")]string Password);