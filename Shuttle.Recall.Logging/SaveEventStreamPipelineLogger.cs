using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Shuttle.Recall.Logging
{
    public class SaveEventStreamPipelineLogger : IHostedService
    {
        private readonly Type _pipelineType = typeof(SaveEventStreamPipeline);
        private readonly ILogger<SaveEventStreamPipelineLogger> _logger;
        private readonly IPipelineFactory _pipelineFactory;
        private readonly IRecallLoggingConfiguration _recallLoggingConfiguration;

        public SaveEventStreamPipelineLogger(ILogger<SaveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration, IPipelineFactory pipelineFactory)
        {
            _logger = Guard.AgainstNull(logger, nameof(logger));
            _recallLoggingConfiguration = Guard.AgainstNull(recallLoggingConfiguration, nameof(recallLoggingConfiguration));
            _pipelineFactory = Guard.AgainstNull(pipelineFactory, nameof(pipelineFactory));

            if (_recallLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
            {
                _pipelineFactory.PipelineCreated += OnPipelineCreated;
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private void OnPipelineCreated(object sender, PipelineEventArgs args)
        {
            if (args.Pipeline.GetType() != _pipelineType)
            {
                return;
            }

            args.Pipeline.RegisterObserver(new SaveEventStreamPipelineObserver(_logger, _recallLoggingConfiguration));
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_recallLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
            {
                _pipelineFactory.PipelineCreated -= OnPipelineCreated;

            }

            await Task.CompletedTask;
        }
    }
}