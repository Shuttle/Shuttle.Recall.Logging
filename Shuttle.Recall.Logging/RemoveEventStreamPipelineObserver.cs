using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class RemoveEventStreamPipelineObserver : PipelineObserver<RemoveEventStreamPipelineLogger>,
        IPipelineObserver<OnBeforeRemoveEventStream>,
        IPipelineObserver<OnRemoveEventStream>,
        IPipelineObserver<OnAfterRemoveEventStream>
    {
        public RemoveEventStreamPipelineObserver(ILogger<RemoveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnBeforeRemoveEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnBeforeRemoveEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnRemoveEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnRemoveEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterRemoveEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterRemoveEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}