using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class GetEventEnvelopePipelineObserver : PipelineObserver<GetEventEnvelopePipelineLogger>,
    IPipelineObserver<OnDeserializeEventEnvelope>,
    IPipelineObserver<OnAfterDeserializeEventEnvelope>,
    IPipelineObserver<OnDecompressEvent>,
    IPipelineObserver<OnAfterDecompressEvent>,
    IPipelineObserver<OnDecryptEvent>,
    IPipelineObserver<OnAfterDecryptEvent>,
    IPipelineObserver<OnDeserializeEvent>,
    IPipelineObserver<OnAfterDeserializeEvent>
{
    public GetEventEnvelopePipelineObserver(ILogger<GetEventEnvelopePipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        : base(logger, recallLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecompressEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecryptEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeEventEnvelope> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecompressEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecryptEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeEvent> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeEventEnvelope> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}