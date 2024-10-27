using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging
{
    public class ThreadingLogger : IHostedService
    {
        private readonly Type _pipelineType = typeof(EventProcessorStartupPipeline);
        private readonly ILogger<ThreadingLogger> _logger;
        private readonly IPipelineFactory _pipelineFactory;
        private readonly RecallLoggingOptions _recallLoggingOptions;

        public ThreadingLogger(IOptions<RecallLoggingOptions> serviceBusLoggingOptions, ILogger<ThreadingLogger> logger, IPipelineFactory pipelineFactory)
        {
            _recallLoggingOptions = Guard.AgainstNull(Guard.AgainstNull(serviceBusLoggingOptions).Value);
            _logger = Guard.AgainstNull(logger);
            _pipelineFactory = Guard.AgainstNull(pipelineFactory);

            if (_recallLoggingOptions.Threading)
            {
                _pipelineFactory.PipelineCreated += OnPipelineCreated;
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private void OnPipelineCreated(object? sender, PipelineEventArgs args)
        {
            if (args.Pipeline.GetType() != _pipelineType)
            {
                return;
            }

            args.Pipeline.RegisterObserver(new ThreadingObserver(_logger));
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_recallLoggingOptions.Threading)
            {
                _pipelineFactory.PipelineCreated -= OnPipelineCreated;
            }

            await Task.CompletedTask;
        }
    }
}