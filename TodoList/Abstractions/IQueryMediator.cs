namespace TodoList.Abstractions;

public interface IQueryMediator
{
    public ValueTask<TResponse> HandleAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken)
        where TResponse : class, IResponse;
}