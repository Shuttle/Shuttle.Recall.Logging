using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Reflection;

namespace Shuttle.Recall.Logging;

public abstract class PipelineObserver<T> :
    IPipelineObserver<OnPipelineStarting>,
    IPipelineObserver<OnPipelineException>,
    IPipelineObserver<OnAbortPipeline>
{
    private readonly Dictionary<Type, int> _eventCounts = new();
    private readonly ILogger<T> _logger;
    private readonly IRecallLoggingConfiguration _recallLoggingConfiguration;

    protected PipelineObserver(ILogger<T> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
    {
        _logger = Guard.AgainstNull(logger);
        _recallLoggingConfiguration = Guard.AgainstNull(recallLoggingConfiguration);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAbortPipeline> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnPipelineException> pipelineContext)
    {
        var type = Guard.AgainstNull(pipelineContext).GetType();

        Increment(type);

        var message = $"exception = '{pipelineContext.Pipeline.Exception?.AllMessages()}'";

        _logger.LogError($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

        await Task.CompletedTask;
    }

    public async Task ExecuteAsync(IPipelineContext<OnPipelineStarting> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    private void Increment(Type type)
    {
        _eventCounts.TryAdd(type, 0);

        _eventCounts[type] += 1;
    }

    protected async Task TraceAsync(IPipelineContext pipelineContext, string message = "")
    {
        var type = Guard.AgainstNull(pipelineContext).GetType();

        if (!_recallLoggingConfiguration.ShouldLogPipelineEventType(type))
        {
            return;
        }

        Increment(type);

        _logger.LogTrace($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

        await Task.CompletedTask;
    }
}