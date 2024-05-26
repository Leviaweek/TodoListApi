using TodoList.Abstractions;
using TodoList.Models.Responses;

namespace TodoList.Models.Queries;

public sealed record GetTodoQuery(Guid UserId, Guid TodoId) : IQuery<GetTodoQueryResponse>;

