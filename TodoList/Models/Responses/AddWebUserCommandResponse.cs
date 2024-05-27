using TodoList.Abstractions;
using TodoList.Models.Dtos;

namespace TodoList.Models.Responses;

public sealed record AddWebUserCommandResponse(WebUserDto? User = null): IResponse;