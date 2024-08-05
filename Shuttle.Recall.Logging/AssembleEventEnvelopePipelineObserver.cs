using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class AssembleEventEnvelopePipelineObserver : PipelineObserver<AssembleEventEnvelopePipelineLogger>,
        IPipelineObserver<OnAssembleEventEnvelope>,
        IPipelineObserver<OnAfterAssembleEventEnvelope>,
        IPipelineObserver<OnSerializeEvent>,
        IPipelineObserver<OnAfterSerializeEvent>,
        IPipelineObserver<OnEncryptEvent>,
        IPipelineObserver<OnAfterEncryptEvent>,
        IPipelineObserver<OnCompressEvent>,
        IPipelineObserver<OnAfterCompressEvent>
    {
        public AssembleEventEnvelopePipelineObserver(ILogger<AssembleEventEnvelopePipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnAssembleEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAssembleEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssembleEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAssembleEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnSerializeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnSerializeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterSerializeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterSerializeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnEncryptEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnEncryptEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterEncryptEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterEncryptEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnCompressEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnCompressEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterCompressEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterCompressEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}