using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class EventProcessingPipelineObserver : PipelineObserver<EventProcessingPipelineLogger>,
    IPipelineObserver<OnGetProjectionEvent>,
    IPipelineObserver<OnAfterGetProjectionEvent>,
    IPipelineObserver<OnGetProjectionEventEnvelope>,
    IPipelineObserver<OnAfterGetProjectionEventEnvelope>,
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
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetProjectionEvent> pipelineContext)
    {
        Guard.AgainstNull(pipelineContext);

        await TraceAsync(pipelineContext, $"working = {pipelineContext.Pipeline.State.GetWorking()} / has event = {pipelineContext.Pipeline.State.GetProjectionEvent() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetProjectionEventEnvelope> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetProjectionEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetProjectionEventEnvelope> pipelineContext)
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