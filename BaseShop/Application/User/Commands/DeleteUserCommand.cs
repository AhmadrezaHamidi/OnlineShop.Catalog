using System;
using Application.Messaging;
using Domain.Abstractions;

namespace Application.User.Commands;

public sealed record DeleteUserCommand(int Id) : ICommand;


internal sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly IRepository<Domain.Shop.Auth.User> _userRepository;

    public DeleteUserCommandHandler(IRepository<Domain.Shop.Auth.User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.Id);
        return Result.Success();
    }
}
