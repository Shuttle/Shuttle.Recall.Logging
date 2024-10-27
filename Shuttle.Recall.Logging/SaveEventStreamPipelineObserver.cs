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
        public SaveEventStreamPipelineObserver(ILogger<SaveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
            : base(logger, recallLoggingConfiguration)
        {
        }

        public async Task ExecuteAsync(IPipelineContext<OnAssembleEventEnvelopes> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterAssembleEventEnvelopes> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnBeforeSavePrimitiveEvents> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnSavePrimitiveEvents> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterSavePrimitiveEvents> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnCommitEventStream> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterCommitEventStream> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }
    }
}