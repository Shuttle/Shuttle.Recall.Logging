using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
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
        public GetEventEnvelopePipelineObserver(ILogger<GetEventEnvelopePipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnDeserializeEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDeserializeEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDeserializeEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDecompressEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDecompressEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecompressEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDecompressEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDecryptEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDecryptEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecryptEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDecryptEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDeserializeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDeserializeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}