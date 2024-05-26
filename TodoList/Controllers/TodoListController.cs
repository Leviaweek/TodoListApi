using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoList.Abstractions;
using TodoList.Models.Dtos;
using TodoList.Models.Queries;

namespace TodoList.Controllers;

[ApiController]
[Route("/api")]
public sealed class TodoListController(ICommandMediator commandMediator, IQueryMediator queryMediator) : ControllerBase
{
    [HttpGet("todo/{id:guid}")]
    public async ValueTask<Results<Ok<GetTodoQueryResponseDto>, NotFound>> GetTodoAsync(Guid id,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty && id == Guid.Empty) return TypedResults.NotFound();
        var query = new GetTodoQuery(userId, id);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpGet("allTodos")]

    public async ValueTask<Results<Ok<GetAllTodoQueryResponseDto>, NotFound>> GetAllTodosAsync([FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var query = new GetAllTodoQuery(userId);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return TypedResults.Ok(response.ToDto());
    }

    [HttpPost("addTodo")]
    public async ValueTask<Results<Ok<AddTodoCommandResponseDto>, NotFound>> AddTodoAsync([FromQuery] Guid userId,
        [FromBody] AddTodoCommandDto command,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var resultCommand = command.ToCommand(userId);
        var response = await commandMediator.HandleAsync(resultCommand, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpPost("updateTodo")]
    public async ValueTask<Results<Ok<UpdateTodoCommandResponseDto>, NotFound>> UpdateTodoAsync([FromQuery] Guid userId,
        [FromBody] UpdateTodoCommandDto command,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var resultCommand = command.ToCommand(userId);
        var response = await commandMediator.HandleAsync(resultCommand, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }
}