using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

[Serializable]
public sealed record AddWebUserCommandDto(
    [property: JsonPropertyName("login")]string Login,
    [property: JsonPropertyName("name")]string Name,
    [property: JsonPropertyName("password")]string Password);