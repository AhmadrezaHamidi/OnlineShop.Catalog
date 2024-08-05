using System;
using Microsoft.Extensions.Logging;

namespace Application.Abstractions.Serilog;

public interface ISerilogService
{
    void CustomLog(LogLevel logLevel, string source, string serviceName, int line = 0, string? userId = "", string? description = "", object? data = null, string? exception = "");
}

