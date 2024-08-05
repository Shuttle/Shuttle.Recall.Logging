using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class EventProcessorStartupPipelineObserver : PipelineObserver<EventProcessorStartupPipelineLogger>,
        IPipelineObserver<OnStartEventProcessing>,
        IPipelineObserver<OnAfterStartEventProcessing>,
        IPipelineObserver<OnConfigureThreadPools>,
        IPipelineObserver<OnAfterConfigureThreadPools>,
        IPipelineObserver<OnStartThreadPools>,
        IPipelineObserver<OnAfterStartThreadPools>
    {
        public EventProcessorStartupPipelineObserver(ILogger<EventProcessorStartupPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnStartEventProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartEventProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartEventProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartEventProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnConfigureThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnConfigureThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterConfigureThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterConfigureThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}