using Microsoft.Extensions.Logging;

namespace Common.Helpers;

public static class LoggerHelper
{
    public static ILoggerFactory CreateConsoleLogger(LogLevel logLevel = LogLevel.Information)
        => LoggerFactory.Create(builder =>
        {
            builder
                .SetMinimumLevel(logLevel)
                .AddConsole()
                .AddDebug();
        });
}