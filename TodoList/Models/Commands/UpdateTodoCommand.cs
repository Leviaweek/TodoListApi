using System.Text.Json.Serialization;
using TodoList.Abstractions;
using TodoList.Models.Dtos;
using TodoList.Models.Responses;

namespace TodoList.Models.Commands;

public sealed record UpdateTodoCommand(Guid UserId, TodoDto Todo) : ICommand<UpdateTodoCommandResponse>;