using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class GetEventStreamPipelineObserver : PipelineObserver<GetEventStreamPipelineLogger>,
    IPipelineObserver<OnBeforeGetStreamEvents>,
    IPipelineObserver<OnGetStreamEvents>,
    IPipelineObserver<OnAfterGetStreamEvents>,
    IPipelineObserver<OnAssembleEventStream>,
    IPipelineObserver<OnAfterAssembleEventStream>
{
    public GetEventStreamPipelineObserver(ILogger<GetEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        : base(logger, recallLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterAssembleEventStream> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetStreamEvents> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAssembleEventStream> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnBeforeGetStreamEvents> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetStreamEvents> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}