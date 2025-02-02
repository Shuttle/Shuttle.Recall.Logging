using System.Collections.Generic;

namespace Shuttle.Recall.Logging;

public class RecallLoggingOptions
{
    public List<TypeLoggingOptions> PipelineEventTypes { get; set; } = [];
    public List<string> PipelineTypes { get; set; } = [];
    public bool Threading { get; set; }
}