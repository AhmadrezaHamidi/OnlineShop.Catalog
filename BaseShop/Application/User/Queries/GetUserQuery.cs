using System;
using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop.Auth;

namespace Application.User.Queries;

public sealed record GetUserQuery(int Id) : IQuery<Domain.Shop.Auth.User>;


internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, Domain.Shop.Auth.User>
{
    private readonly IRepository<Domain.Shop.Auth.User> _userRepository;

    public GetUserQueryHandler(IRepository<Domain.Shop.Auth.User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Domain.Shop.Auth.User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            return Result.Failure<Domain.Shop.Auth.User>(UserError.userNotFound);
        }
        return Result.Success(user);
    }
}