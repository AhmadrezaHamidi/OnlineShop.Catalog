using System;
using MediatR;

namespace Application.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
   where TQuery : IQuery<TResponse>
{
}

