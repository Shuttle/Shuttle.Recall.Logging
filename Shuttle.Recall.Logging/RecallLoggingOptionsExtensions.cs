using System;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging;

public static class RecallLoggingOptionsExtensions
{
    public static RecallLoggingOptions AddPipelineEventType<T>(this RecallLoggingOptions recallLoggingOptions, LogLevel? logLevel = null)
    {
        return recallLoggingOptions.AddPipelineEventType(typeof(T), logLevel);
    }

    public static RecallLoggingOptions AddPipelineEventType(this RecallLoggingOptions recallLoggingOptions, Type type, LogLevel? logLevel = null)
    {
        Guard.AgainstNull(type);

        if (recallLoggingOptions.PipelineEventTypes == null)
        {
            throw new InvalidOperationException(Resources.PipelineTypesNullException);
        }

        recallLoggingOptions.PipelineEventTypes.Add(new() {Type = Guard.AgainstNullOrEmptyString(type.FullName), LogLevel = logLevel});

        return recallLoggingOptions;
    }

    public static RecallLoggingOptions AddPipelineType<T>(this RecallLoggingOptions recallLoggingOptions)
    {
        return recallLoggingOptions.AddPipelineType(typeof(T));
    }

    public static RecallLoggingOptions AddPipelineType(this RecallLoggingOptions recallLoggingOptions, Type type)
    {
        Guard.AgainstNull(type);

        if (recallLoggingOptions.PipelineTypes == null)
        {
            throw new InvalidOperationException(Resources.PipelineTypesNullException);
        }

        recallLoggingOptions.PipelineTypes.Add(Guard.AgainstNullOrEmptyString(type.FullName));

        return recallLoggingOptions;
    }
}