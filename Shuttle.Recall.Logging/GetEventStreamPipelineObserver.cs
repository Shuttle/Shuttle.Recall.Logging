using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class GetEventStreamPipelineObserver : PipelineObserver<GetEventStreamPipelineLogger>,
        IPipelineObserver<OnBeforeGetStreamEvents>,
        IPipelineObserver<OnGetStreamEvents>,
        IPipelineObserver<OnAfterGetStreamEvents>,
        IPipelineObserver<OnAssembleEventStream>,
        IPipelineObserver<OnAfterAssembleEventStream>
    {
        public GetEventStreamPipelineObserver(ILogger<GetEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnBeforeGetStreamEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnBeforeGetStreamEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnGetStreamEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetStreamEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterGetStreamEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterGetStreamEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAssembleEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAssembleEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssembleEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAssembleEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}