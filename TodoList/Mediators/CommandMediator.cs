using System.Runtime.CompilerServices;
using TodoList.Abstractions;
using TodoList.Models.Commands;
using TodoList.Models.Responses;

namespace TodoList.Mediators;

public sealed class CommandMediator(
    ICommandHandler<AddTodoCommand, AddTodoCommandResponse> addTodoCommandHandler,
    ICommandHandler<UpdateTodoCommand, UpdateTodoCommandResponse> updateTodoCommandHandler,
    ICommandHandler<DeleteTodoCommand, DeleteTodoCommandResponse> deleteTodoCommandHandler,
    ICommandHandler<AddWebUserCommand, AddWebUserCommandResponse> addWebUserCommandHandler,
    ICommandHandler<LoginWebUserCommand, LoginWebUserCommandResponse> loginWebUserCommandHandler) : ICommandMediator
{
    public async ValueTask<TResponse> HandleAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
        where TResponse: class, IResponse
    {
        switch (command)
        {
            case AddTodoCommand addTodoCommand:
            {
                var response = await addTodoCommandHandler.HandleAsync(addTodoCommand, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            case UpdateTodoCommand updateTodoCommand:
            {
                var response = await updateTodoCommandHandler.HandleAsync(updateTodoCommand, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            case DeleteTodoCommand deleteTodoCommand:
            {
                var response = await deleteTodoCommandHandler.HandleAsync(deleteTodoCommand, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            case AddWebUserCommand addWebUserCommand:
            {
                var response = await addWebUserCommandHandler.HandleAsync(addWebUserCommand, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            case LoginWebUserCommand loginWebUserCommand:
            {
                var response = await loginWebUserCommandHandler.HandleAsync(loginWebUserCommand, cancellationToken);
                return Unsafe.As<TResponse>(response);
            }
            default:
                throw new InvalidOperationException();
        }
    }
}