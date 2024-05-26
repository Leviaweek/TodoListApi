using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoList.Abstractions;
using TodoList.Models.Dtos;
using TodoList.Models.Queries;

namespace TodoList.Controllers;

[ApiController]
[Route("/api/todos")]
public sealed class TodoListController(ICommandMediator commandMediator, IQueryMediator queryMediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async ValueTask<Results<Ok<GetTodoQueryResponseDto>, NotFound>> GetTodoAsync(Guid id,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || id == Guid.Empty) return TypedResults.NotFound();
        var query = new GetTodoQuery(userId, id);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpGet("all")]

    public async ValueTask<Results<Ok<GetAllTodoQueryResponseDto>, NotFound>> GetAllTodosAsync([FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var query = new GetAllTodoQuery(userId);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return TypedResults.Ok(response.ToDto());
    }

    [HttpPost("add")]
    public async ValueTask<Results<Ok<AddTodoCommandResponseDto>, NotFound>> AddTodoAsync([FromQuery] Guid userId,
        [FromBody] AddTodoCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var command = dto.ToCommand(userId);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpPost("update")]
    public async ValueTask<Results<Ok<UpdateTodoCommandResponseDto>, NotFound>> UpdateTodoAsync([FromQuery] Guid userId,
        [FromBody] UpdateTodoCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || dto.TodoId == Guid.Empty) return TypedResults.NotFound();
        var command = dto.ToCommand(userId);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpDelete]
    public async ValueTask<Results<Ok<DeleteTodoCommandResponseDto>, NotFound>> DeleteTodoAsync([FromQuery] Guid userId,
        [FromBody] DeleteTodoCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || dto.TodoId == Guid.Empty) return TypedResults.NotFound();
        var command = dto.ToCommand(userId);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return TypedResults.Ok(response.ToDto());
    }
}