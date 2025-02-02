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
    protected readonly ILogger<T> Logger;
    protected readonly IRecallLoggingConfiguration RecallLoggingConfiguration;

    private readonly Dictionary<Type, int> _eventCounts = new();

    protected PipelineObserver(ILogger<T> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
    {
        Logger = Guard.AgainstNull(logger);
        RecallLoggingConfiguration = Guard.AgainstNull(recallLoggingConfiguration);
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

        Logger.LogError($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

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
        var type = Guard.AgainstNull(pipelineContext).EventType;

        if (!RecallLoggingConfiguration.ShouldLogPipelineEventType(type, LogLevel.Trace))
        {
            return;
        }

        Increment(type);

        Logger.LogTrace($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

        await Task.CompletedTask;
    }
}