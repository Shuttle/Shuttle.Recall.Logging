using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class EventProcessingPipelineObserver : PipelineObserver<EventProcessingPipelineLogger>,
        IPipelineObserver<OnGetProjectionEvent>,
        IPipelineObserver<OnAfterGetProjectionEvent>,
        IPipelineObserver<OnGetProjectionEventEnvelope>,
        IPipelineObserver<OnAfterGetProjectionEventEnvelope>,
        IPipelineObserver<OnProcessEvent>,
        IPipelineObserver<OnAfterProcessEvent>,
        IPipelineObserver<OnAcknowledgeEvent>,
        IPipelineObserver<OnAfterAcknowledgeEvent>
    {
        public EventProcessingPipelineObserver(ILogger<EventProcessingPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
            : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnGetProjectionEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetProjectionEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterGetProjectionEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterGetProjectionEvent pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            await Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has event = {pipelineEvent.Pipeline.State.GetProjectionEvent() != null}");
        }

        public void Execute(OnGetProjectionEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetProjectionEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterGetProjectionEventEnvelope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterGetProjectionEventEnvelope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnProcessEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnProcessEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterProcessEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterProcessEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAcknowledgeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAcknowledgeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAcknowledgeEvent pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAcknowledgeEvent pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}