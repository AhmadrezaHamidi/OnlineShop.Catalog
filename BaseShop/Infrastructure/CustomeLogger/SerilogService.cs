using System;
using Application.Abstractions.Serilog;
using Microsoft.Extensions.Logging;

namespace Infrastructure.CustomeLogger
{
    public class SerilogService : ISerilogService
    {
        private readonly ILogger<SerilogService> _logger;

        public SerilogService(ILogger<SerilogService> logger)
        {
            _logger = logger;
        }

        public void CustomLog(LogLevel logLevel, string source, string serviceName, int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "")
        {
            string message = $"{description}, User: {userId}, Data: {data}";
            switch (logLevel)
            {
                case LogLevel.Information:
                    _logger.CustomeLogInformation(message, line, source, serviceName, exception);
                    break;
                case LogLevel.Warning:
                    _logger.CustomeLogWarning(message, line, source, serviceName, exception);
                    break;
                case LogLevel.Error:
                    _logger.CustomeLogError(message, line, source, serviceName, exception);
                    break;
                default:
                    _logger.LogInformation(message); // Default logging
                    break;
            }
        }

    }

    public static class CustomLogger
    {
        public static void CustomeLogInformation(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
        {
            logger.LogInformation($"CreatedAt: {DateTime.Now}, ExceptionMessage: {ExceptionMessage}, Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName}");
        }

        public static void CustomeLogWarning(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
        {
            logger.LogWarning($"CreatedAt: {DateTime.Now}, ExceptionMessage: {ExceptionMessage}, Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName}");
        }

        public static void CustomeLogError(this ILogger logger, string Message, int Line, string Service, string ServiceName, string? ExceptionMessage = null)
        {
            logger.LogError($"Message: {Message}, Line: {Line}, Service: {Service}, ServiceName: {ServiceName},ExceptionMessage: {ExceptionMessage}");
        }
    }
}

