using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoList.Abstractions;
using TodoList.Models.Dtos;
using TodoList.Models.Queries;
using TodoList.Models.Responses;

namespace TodoList.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController(ICommandMediator commandMediator, ILogger<UserController> logger)
{
    [HttpPost("web")]
    public async ValueTask<Results<Ok<AddWebUserCommandResponseDto>, NotFound>> AddWebUserAsync(
        [FromBody] AddWebUserCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        var command = dto.ToCommand();
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        logger.LogInformation("{}", response.ToString());
        return response.User is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }
    [HttpPost("web/login")]
    public async ValueTask<Results<Ok<LoginWebUserCommandResponseDto>, NotFound>> GetWebUserAsync(
        [FromBody] LoginWebUserCommandDto dto,
        CancellationToken cancellationToken = default)
    {
        var command = dto.ToCommand();
        var response = await commandMediator.HandleAsync(command, cancellationToken);
        logger.LogInformation("{}", response.ToString());
        return response.User is null ? TypedResults.NotFound() : TypedResults.Ok(response.ToDto());
    }
}