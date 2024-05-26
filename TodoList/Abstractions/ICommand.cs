namespace TodoList.Abstractions;

public interface ICommand<out TResponse>
    where TResponse: IResponse;