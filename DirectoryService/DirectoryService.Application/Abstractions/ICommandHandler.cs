using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Application.Abstractions;

public interface ICommand;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand
{
    Task<Result<TResponse, Failure>> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<UnitResult<Failure>> Handle(TCommand command, CancellationToken cancellationToken);
}