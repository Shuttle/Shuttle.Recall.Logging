using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class AddProjectionPipelineObserver : PipelineObserver<AddProjectionPipelineLogger>,
        IPipelineObserver<OnBeforeAddProjection>,
        IPipelineObserver<OnAddProjection>,
        IPipelineObserver<OnAfterAddProjection>
    {
        public AddProjectionPipelineObserver(ILogger<AddProjectionPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) : base(logger, recallLoggingConfiguration)
        {
        }

        public void Execute(OnBeforeAddProjection pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnBeforeAddProjection pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAddProjection pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAddProjection pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAddProjection pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAddProjection pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}