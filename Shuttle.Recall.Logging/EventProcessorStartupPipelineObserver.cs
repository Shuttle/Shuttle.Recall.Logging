using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class EventProcessorStartupPipelineObserver : PipelineObserver<EventProcessorStartupPipelineLogger>,
    IPipelineObserver<OnStartEventProcessing>,
    IPipelineObserver<OnAfterStartEventProcessing>,
    IPipelineObserver<OnConfigureThreadPools>,
    IPipelineObserver<OnAfterConfigureThreadPools>,
    IPipelineObserver<OnStartThreadPools>,
    IPipelineObserver<OnAfterStartThreadPools>
{
    public EventProcessorStartupPipelineObserver(ILogger<EventProcessorStartupPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        : base(logger, recallLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterConfigureThreadPools> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterStartEventProcessing> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterStartThreadPools> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnConfigureThreadPools> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnStartEventProcessing> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnStartThreadPools> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}