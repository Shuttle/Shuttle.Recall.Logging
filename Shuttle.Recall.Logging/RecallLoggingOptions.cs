using System.Collections.Generic;

namespace Shuttle.Recall.Logging
{
    public class RecallLoggingOptions
    {
        public List<string> PipelineEventTypes { get; set; } = new List<string>();
        public List<string> PipelineTypes { get; set; } = new List<string>();
        public bool Threading { get; set; }
    }
}