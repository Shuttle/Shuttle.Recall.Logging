using System;

namespace Shuttle.Recall.Logging;

public interface IRecallLoggingConfiguration
{
    bool ShouldLogPipelineEventType(Type pipelineEventType);
    bool ShouldLogPipelineType(Type pipelineType);
}