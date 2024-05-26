namespace TodoList.Abstractions;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse: IResponse
{
    public ValueTask<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}