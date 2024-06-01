using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoList.Abstractions;
using TodoList.Models.Commands;
using TodoList.Models.Dtos;
using TodoList.Models.Queries;

namespace TodoList.Controllers;

[ApiController]
[Route("/api/todos")]
public sealed class TodoListController(ICommandMediator commandMediator, IQueryMediator queryMediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async ValueTask<Results<Ok<TodoDto>, NotFound>> GetTodoAsync(Guid id,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || id == Guid.Empty) return TypedResults.NotFound();
        var query = new GetTodoQuery(userId, id);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.Todo);
    }

    [HttpGet("all")]

    public async ValueTask<Results<Ok<List<TodoDto>>, NotFound>> GetAllTodosAsync([FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var query = new GetAllTodoQuery(userId);
        var response = await queryMediator.HandleAsync(query, cancellationToken);
        return TypedResults.Ok(response.Todos);
    }

    [HttpPost]
    public async ValueTask<Results<Ok<AddTodoCommandResponseDto>, NotFound>> AddTodoAsync([FromQuery] Guid userId,
        [FromBody] AddTodoCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty) return TypedResults.NotFound();
        var command = dto.ToCommand(userId);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpPut("{id:guid}")]
    public async ValueTask<Results<Ok<UpdateTodoCommandResponseDto>, NotFound>> UpdateTodoAsync([FromQuery] Guid userId,
        [FromBody] TodoDto dto, Guid id,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || dto.Id == Guid.Empty) return TypedResults.NotFound();
        if (dto.Id != id) return TypedResults.NotFound();
        var command = new UpdateTodoCommand(userId, dto);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return response.Todo is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<Results<Ok<DeleteTodoCommandResponseDto>, NotFound>> DeleteTodoAsync([FromQuery] Guid userId,
        Guid id,
        CancellationToken cancellationToken = default)
    {
        if (userId == Guid.Empty || id == Guid.Empty) return TypedResults.NotFound();
        var command = new DeleteTodoCommand(userId, id);
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        return TypedResults.Ok(response.ToDto());
    }
}