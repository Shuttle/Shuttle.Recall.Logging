using System;

namespace Shuttle.Recall.Logging
{
    public interface IRecallLoggingConfiguration
    {
        bool ShouldLogPipelineType(Type pipelineType);
        bool ShouldLogPipelineEventType(Type pipelineEventType);
    }
}