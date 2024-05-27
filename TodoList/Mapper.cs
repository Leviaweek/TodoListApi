using TodoList.Database.Models;
using TodoList.Models.Commands;
using TodoList.Models.Dtos;
using TodoList.Models.Responses;

namespace TodoList;

public static class Mapper
{
    public static TodoDto ToDto(this Todo todo) => new(
        Id: todo.Id,
        Title: todo.Title,
        Description: todo.Description,
        IsCompleted: todo.IsCompleted,
        ExecutionDate: todo.ExecutionDate,
        CreatedAt: todo.CreatedAt);

    public static GetTodoQueryResponseDto ToDto(this GetTodoQueryResponse response) =>
        new(response.Todo ?? throw new ArgumentNullException(nameof(response)));

    public static GetAllTodoQueryResponseDto ToDto(this GetAllTodoQueryResponse response) => new(response.Todos);

    public static AddTodoCommandResponseDto ToDto(this AddTodoCommandResponse response) =>
        new(response.Todo ?? throw new ArgumentNullException(nameof(response)));

    public static UpdateTodoCommandResponseDto ToDto(this UpdateTodoCommandResponse response) =>
        new(response.Todo ?? throw new ArgumentNullException(nameof(response)));

    public static DeleteTodoCommandResponseDto ToDto(this DeleteTodoCommandResponse command) => new(command.IsDeleted);
    public static AddTodoCommand ToCommand(this AddTodoCommandDto dto, Guid userId) => new(userId,
        Title: dto.Title,
        Description: dto.Description,
        ExecutionDate: dto.ExecutionTime);
    public static AddWebUserCommand ToCommand(this AddWebUserCommandDto dto) => new(
        Login: dto.Login,
        Name: dto.Name,
        Password: dto.Password);
    public static AddWebUserCommandResponseDto ToDto(this AddWebUserCommandResponse dto) =>
        new(dto.User ?? throw new ArgumentNullException(nameof(dto)));

    public static WebUserDto ToDto(this WebUser user, string name) => new(
        UserId: user.UserId,
        Login: user.Login,
        Password: user.Password,
        Name: name);

    public static LoginWebUserCommand ToCommand(this LoginWebUserCommandDto dto) =>
        new(dto.Login,
            dto.Password);

    public static LoginWebUserCommandResponseDto ToDto(this LoginWebUserCommandResponse dto) => new(dto.User ??
        throw new ArgumentNullException(nameof(dto)));
}