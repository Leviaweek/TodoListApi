namespace TodoList.Abstractions;

public interface IQuery<out TResponse>
    where TResponse: IResponse;