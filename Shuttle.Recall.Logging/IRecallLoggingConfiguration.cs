using System;
using Microsoft.Extensions.Logging;

namespace Shuttle.Recall.Logging;

public interface IRecallLoggingConfiguration
{
    bool ShouldLogPipelineEventType(Type pipelineEventType, LogLevel? logLevel = null);
    bool ShouldLogPipelineType(Type pipelineType);
}