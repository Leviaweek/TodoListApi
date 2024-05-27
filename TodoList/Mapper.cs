using TodoList.Database.Models;
using TodoList.Models;
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
        new(response.Todo ?? throw new InvalidOperationException());

    public static GetAllTodoQueryResponseDto ToDto(this GetAllTodoQueryResponse response) => new(response.Todos);

    public static AddTodoCommandResponseDto ToDto(this AddTodoCommandResponse response) =>
        new(response.Todo ?? throw new InvalidOperationException());

    public static UpdateTodoCommandResponseDto ToDto(this UpdateTodoCommandResponse response) =>
        new(response.Todo ?? throw new InvalidOperationException());

    public static DeleteTodoCommandResponseDto ToDto(this DeleteTodoCommandResponse command) =>
        new DeleteTodoCommandResponseDto(command.IsDeleted);
    public static AddTodoCommand ToCommand(this AddTodoCommandDto dto, Guid userId) => new(userId,
        Title: dto.Title,
        Description: dto.Description,
        ExecutionDate: dto.ExecutionTime);
}