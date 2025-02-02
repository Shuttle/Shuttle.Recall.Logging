using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class RemoveEventStreamPipelineObserver : PipelineObserver<RemoveEventStreamPipelineLogger>,
    IPipelineObserver<OnBeforeRemoveEventStream>,
    IPipelineObserver<OnRemoveEventStream>,
    IPipelineObserver<OnAfterRemoveEventStream>
{
    public RemoveEventStreamPipelineObserver(ILogger<RemoveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        : base(logger, recallLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterRemoveEventStream> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnBeforeRemoveEventStream> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnRemoveEventStream> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}