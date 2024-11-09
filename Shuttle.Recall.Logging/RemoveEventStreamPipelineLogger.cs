using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class RemoveEventStreamPipelineLogger : IHostedService
{
    private readonly ILogger<RemoveEventStreamPipelineLogger> _logger;
    private readonly IPipelineFactory _pipelineFactory;
    private readonly Type _pipelineType = typeof(RemoveEventStreamPipeline);
    private readonly IRecallLoggingConfiguration _recallLoggingConfiguration;

    public RemoveEventStreamPipelineLogger(ILogger<RemoveEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration, IPipelineFactory pipelineFactory)
    {
        _logger = Guard.AgainstNull(logger);
        _recallLoggingConfiguration = Guard.AgainstNull(recallLoggingConfiguration);
        _pipelineFactory = Guard.AgainstNull(pipelineFactory);

        if (_recallLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
        {
            _pipelineFactory.PipelineCreated += OnPipelineCreated;
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_recallLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
        {
            _pipelineFactory.PipelineCreated -= OnPipelineCreated;
        }

        await Task.CompletedTask;
    }

    private void OnPipelineCreated(object? sender, PipelineEventArgs args)
    {
        if (args.Pipeline.GetType() != _pipelineType)
        {
            return;
        }

        args.Pipeline.AddObserver(new RemoveEventStreamPipelineObserver(_logger, _recallLoggingConfiguration));
    }
}