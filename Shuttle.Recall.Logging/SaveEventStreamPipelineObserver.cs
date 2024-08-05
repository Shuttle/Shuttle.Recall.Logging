using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class SaveEventStreamPipelineObserver : PipelineObserver<SaveEventStreamPipelineLogger>,
        IPipelineObserver<OnAssembleEventEnvelopes>,
        IPipelineObserver<OnAfterAssembleEventEnvelopes>,
        IPipelineObserver<OnBeforeSavePrimitiveEvents>,
        IPipelineObserver<OnSavePrimitiveEvents>,
        IPipelineObserver<OnAfterSavePrimitiveEvents>,
        IPipelineObserver<OnCommitEventStream>,
        IPipelineObserver<OnAfterCommitEventStream>
    {
        public SaveEventStreamPipelineObserver(ILogger<SaveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnAssembleEventEnvelopes pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAssembleEventEnvelopes pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssembleEventEnvelopes pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAssembleEventEnvelopes pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnBeforeSavePrimitiveEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnBeforeSavePrimitiveEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnSavePrimitiveEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnSavePrimitiveEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterSavePrimitiveEvents pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterSavePrimitiveEvents pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnCommitEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnCommitEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterCommitEventStream pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterCommitEventStream pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}