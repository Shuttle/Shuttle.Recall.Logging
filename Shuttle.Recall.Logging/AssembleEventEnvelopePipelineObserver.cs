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
        public AssembleEventEnvelopePipelineObserver(ILogger<AssembleEventEnvelopePipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) 
            : base(logger, recallLoggingConfiguration)
        {
        }

        public async Task ExecuteAsync(IPipelineContext<OnAssembleEventEnvelope> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterAssembleEventEnvelope> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnSerializeEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterSerializeEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnEncryptEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterEncryptEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnCompressEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterCompressEvent> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }
    }
}