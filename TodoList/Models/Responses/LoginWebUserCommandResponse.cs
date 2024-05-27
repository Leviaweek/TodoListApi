using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

public sealed record LoginWebUserCommandResponse(WebUserDto? User = null): IResponse;