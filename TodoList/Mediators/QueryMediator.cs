using System.Runtime.CompilerServices;
using TodoList.Abstractions;
using TodoList.Models.Queries;
using TodoList.Models.Responses;

namespace TodoList.Mediators;

public sealed class QueryMediator(IQueryHandler<GetAllTodoQuery, GetAllTodoQueryResponse> getAllTodoQueryHandler,
    IQueryHandler<GetTodoQuery, GetTodoQueryResponse> getTodoQueryHandler)
    : IQueryMediator
{
    public async ValueTask<TResponse> HandleAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken)   
        where TResponse: class, IResponse
    {
        switch (query)
        {
            case GetTodoQuery getTodoQuery:

            {
                var response = await getTodoQueryHandler.HandleAsync(getTodoQuery, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            case GetAllTodoQuery getAllTodoQuery:
            {
                var response = await getAllTodoQueryHandler.HandleAsync(getAllTodoQuery, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            default:
                throw new InvalidOperationException();
        }
    }
}