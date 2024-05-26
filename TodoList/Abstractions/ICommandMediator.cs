namespace TodoList.Abstractions;

public interface ICommandMediator
{
    public ValueTask<TResponse> HandleAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
        where TResponse: class, IResponse;
}