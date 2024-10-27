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
        public AddProjectionPipelineObserver(ILogger<AddProjectionPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration) 
            : base(logger, recallLoggingConfiguration)
        {
        }

        public async Task ExecuteAsync(IPipelineContext<OnBeforeAddProjection> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAddProjection> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }

        public async Task ExecuteAsync(IPipelineContext<OnAfterAddProjection> pipelineContext)
        {
            await TraceAsync(pipelineContext);
        }
    }
}