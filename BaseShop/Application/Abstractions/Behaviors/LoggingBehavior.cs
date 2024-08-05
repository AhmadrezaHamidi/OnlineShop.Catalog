using System;
using Application.Abstractions.Serilog;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
       : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IBaseRequest
       where TResponse : Result
    {
        private readonly ISerilogService _serilogService;

        public LoggingBehavior(ISerilogService serilogService)
        {
            _serilogService = serilogService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            string? name = request.GetType().Name;

            try
            {
                _serilogService.CustomLog(LogLevel.Trace, "Peyman.Application.Interfaces.Services", name, line: 34, description: $"Executing request {name}");
                TResponse? result = await next();

                if (result.IsSuccess)
                {
                    _serilogService.CustomLog(LogLevel.Trace, "Peyman.Application.Interfaces.Services", name, line: 39, description: $"Request {name} processed successfully");
                }
                else
                {
                    using (LogContext.PushProperty("Error", result.Error, true))
                    {
                        _serilogService?.CustomLog(LogLevel.Error, "Peyman.Application.Interfaces.Services", name, line: 45, description: $"Request {name} processed with error", exception: $"{result.Error.Code}: {result.Error.Name}");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _serilogService?.CustomLog(LogLevel.Error, "Peyman.Application.Interfaces.Services", name, description: $"Request {name} processed with error", exception: $"{ex}");
                throw;
            }
        }
    }
}

