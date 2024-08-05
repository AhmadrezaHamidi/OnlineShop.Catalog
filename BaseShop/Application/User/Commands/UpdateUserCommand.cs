using System;
using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop.Auth;

namespace Application.User.Commands
{
    public sealed record UpdateUserCommand(int Id, string Username, string PasswordHash, string Email, string FirstName, string LastName, string Role) : ICommand<Domain.Shop.Auth.User>;


    internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Domain.Shop.Auth.User>
    {
        private readonly IRepository<Domain.Shop.Auth.User> _userRepository;

        public UpdateUserCommandHandler(IRepository<Domain.Shop.Auth.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Domain.Shop.Auth.User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return Result.Failure<Domain.Shop.Auth.User>(UserError.userNotFound);
            }

            user.Username = request.Username;
            user.PasswordHash = request.PasswordHash;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Role = request.Role;

            await _userRepository.UpdateAsync(user);
            return Result.Success(user);
        }
    }


}

