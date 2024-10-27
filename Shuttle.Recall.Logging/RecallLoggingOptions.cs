using System.Collections.Generic;

namespace Shuttle.Recall.Logging
{
    public class RecallLoggingOptions
    {
        public List<string> PipelineEventTypes { get; set; } = new();
        public List<string> PipelineTypes { get; set; } = new();
        public bool Threading { get; set; }
    }
}