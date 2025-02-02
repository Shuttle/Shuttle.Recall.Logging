using Microsoft.Extensions.Logging;
using System;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging;

public static class RecallLoggingConfigurationExtensions
{
    public static bool ShouldLogPipelineEventType<T>(this IRecallLoggingConfiguration configuration, LogLevel? logLevel = null)
    {
        return Guard.AgainstNull(configuration).ShouldLogPipelineEventType(typeof(T), logLevel);
    }

    public static bool ShouldLogPipelineType<T>(this IRecallLoggingConfiguration configuration)
    {
        return Guard.AgainstNull(configuration).ShouldLogPipelineType(typeof(T));
    }
}