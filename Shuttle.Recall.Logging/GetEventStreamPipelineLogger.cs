﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Recall.Logging;

public class GetEventStreamPipelineLogger : IHostedService
{
    private readonly ILogger<GetEventStreamPipelineLogger> _logger;
    private readonly IPipelineFactory _pipelineFactory;
    private readonly Type _pipelineType = typeof(GetEventStreamPipeline);
    private readonly IRecallLoggingConfiguration _recallLoggingConfiguration;

    public GetEventStreamPipelineLogger(ILogger<GetEventStreamPipelineLogger> logger, IRecallLoggingConfiguration recallLoggingConfiguration, IPipelineFactory pipelineFactory)
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

        args.Pipeline.AddObserver(new GetEventStreamPipelineObserver(_logger, _recallLoggingConfiguration));
    }
}