using System;
using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop.Auth;

namespace Application.User.Commands
{
    public sealed record CreateUserCommand(string Username, string PasswordHash, string Email, string FirstName, string LastName, string Role)
        : ICommand<Domain.Shop.Auth.User>;


    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Domain.Shop.Auth.User>
    {
        private readonly IRepository<Domain.Shop.Auth.User> _userRepository;

        public CreateUserCommandHandler(IRepository<Domain.Shop.Auth.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Domain.Shop.Auth.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Shop.Auth.User
            {
                Username = request.Username,
                PasswordHash = request.PasswordHash,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role
            };

            await _userRepository.AddAsync(user);
            return Result.Success(user);
        }
    }



}

