using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging;

public class RecallLoggingConfiguration : IRecallLoggingConfiguration
{
    private readonly List<string> _pipelineEventTypes = [];
    private readonly List<string> _pipelineTypes = [];

    public RecallLoggingConfiguration(ILogger<RecallLoggingConfiguration> logger, IOptions<RecallLoggingOptions> recallLoggingOptions)
    {
        Guard.AgainstNull(Guard.AgainstNull(recallLoggingOptions).Value);
        Guard.AgainstNull(logger);

        foreach (var pipelineType in recallLoggingOptions.Value.PipelineTypes)
        {
            try
            {
                _pipelineTypes.Add(pipelineType);
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
                _pipelineEventTypes.Add($"{pipelineEventType.Type}-{pipelineEventType.LogLevel?.ToString() ?? "*"}");
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

        return !_pipelineTypes.Any() || _pipelineTypes.Contains(Guard.AgainstNullOrEmptyString(pipelineType.FullName));
    }

    public bool ShouldLogPipelineEventType(Type pipelineEventType, LogLevel? logLevel = null)
    {
        Guard.AgainstNull(pipelineEventType);

        return !_pipelineEventTypes.Any() || _pipelineEventTypes.Contains($"{Guard.AgainstNullOrEmptyString(pipelineEventType.FullName)}-{logLevel?.ToString() ?? "*"}");
    }
}