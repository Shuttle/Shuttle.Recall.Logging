using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging
{
    public class RecallLoggingConfiguration : IRecallLoggingConfiguration
    {
        private readonly List<Type> _pipelineTypes = new();
        private readonly List<Type> _pipelineEventTypes = new();
        
        public RecallLoggingConfiguration(IOptions<RecallLoggingOptions> recallLoggingOptions, ILogger<RecallLoggingConfiguration> logger)
        {
            Guard.AgainstNull(Guard.AgainstNull(recallLoggingOptions).Value);
            Guard.AgainstNull(logger, nameof(logger));

            foreach (var pipelineType in recallLoggingOptions.Value.PipelineTypes)
            {
                try
                {
                    _pipelineTypes.Add(Guard.AgainstNull(Type.GetType(pipelineType)));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }    
            }

            foreach (var pipelineEventType in recallLoggingOptions.Value.PipelineEventTypes)
            {
                try
                {
                    _pipelineEventTypes.Add(Guard.AgainstNull(Type.GetType(pipelineEventType)));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }

        public bool ShouldLogPipelineType(Type pipelineType)
        {
            Guard.AgainstNull(pipelineType);

            return !_pipelineTypes.Any() || _pipelineTypes.Contains(pipelineType);
        }

        public bool ShouldLogPipelineEventType(Type pipelineEventType)
        {
            Guard.AgainstNull(pipelineEventType);

            return !_pipelineEventTypes.Any() || _pipelineEventTypes.Contains(pipelineEventType);
        }
    }
}