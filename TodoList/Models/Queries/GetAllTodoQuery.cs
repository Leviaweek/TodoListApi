using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Queries;

public sealed record GetAllTodoQuery(Guid UserId) : IQuery<GetAllTodoQueryResponse>;