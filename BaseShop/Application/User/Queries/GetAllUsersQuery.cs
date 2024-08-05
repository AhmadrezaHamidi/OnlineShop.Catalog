using System;
using Application.Messaging;
using Domain.Abstractions;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery : IQuery<IEnumerable<Domain.Shop.Auth.User>>;

    internal sealed class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<Domain.Shop.Auth.User>>
    {
        private readonly IRepository<Domain.Shop.Auth.User> _userRepository;

        public GetAllUsersQueryHandler(IRepository<Domain.Shop.Auth.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<Domain.Shop.Auth.User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return Result.Success(users);
        }
    }
}

