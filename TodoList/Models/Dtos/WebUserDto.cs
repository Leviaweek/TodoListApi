using System.Text.Json.Serialization;

namespace TodoList.Models.Dtos;

public sealed record WebUserDto(
    [property: JsonPropertyName("userId")]Guid UserId,
    [property: JsonPropertyName("login")]string Login,
    [property: JsonPropertyName("password")]string Password,
    [property: JsonPropertyName("name")] string Name);