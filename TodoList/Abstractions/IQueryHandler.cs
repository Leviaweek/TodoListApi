namespace TodoList.Abstractions;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse: IResponse
{
    public ValueTask<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);
}