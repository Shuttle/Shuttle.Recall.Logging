using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class EventProcessingPipelineObserver : PipelineObserver<EventProcessingPipelineLogger>,
    IPipelineObserver<OnGetEvent>,
    IPipelineObserver<OnAfterGetEvent>,
    IPipelineObserver<OnGetEventEnvelope>,
    IPipelineObserver<OnAfterGetEventEnvelope>,
    IPipelineObserver<OnHandleEvent>,
    IPipelineObserver<OnAfterHandleEvent>,
    IPipelineObserver<OnAcknowledgeEvent>,
    IPipelineObserver<OnAfterAcknowledgeEvent>
{
    public EventProcessingPipelineObserver(ILogger<EventProcessingPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        : base(logger, recallLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAcknowledgeEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterAcknowledgeEvent> pipelineContext)
    {
        var projectionEvent = Guard.AgainstNull(pipelineContext).Pipeline.State.GetProjectionEvent();

        await TraceAsync(pipelineContext);

        if (RecallLoggingConfiguration.ShouldLogPipelineEventType<OnAfterAcknowledgeEvent>(LogLevel.Trace))
        {
            Logger.LogDebug($"[OnAfterAcknowledgeEvent] : projection (name = '{projectionEvent.Projection.Name}' / sequence number = {projectionEvent.Projection.SequenceNumber}) / primitive event (id = '{projectionEvent.PrimitiveEvent.Id}' / correlation id = '{projectionEvent.PrimitiveEvent.CorrelationId?.ToString("D") ?? "(empty)"}' / event id = '{projectionEvent.PrimitiveEvent.EventId}' / event type = '{projectionEvent.PrimitiveEvent.EventType}' / sequence number = {projectionEvent.PrimitiveEvent.SequenceNumber})");
        }
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetEvent> pipelineContext)
    {
        Guard.AgainstNull(pipelineContext);

        await TraceAsync(pipelineContext, $"working = {pipelineContext.Pipeline.State.GetWorking()}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetEventEnvelope> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetEventEnvelope> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnHandleEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterHandleEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}