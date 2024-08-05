using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Reflection;

namespace Shuttle.Recall.Logging
{
    public abstract class PipelineObserver<T> :
        IPipelineObserver<OnPipelineStarting>,
        IPipelineObserver<OnPipelineException>,
        IPipelineObserver<OnAbortPipeline>
    {
        private readonly ILogger<T> _logger;
        private readonly IRecallLoggingConfiguration _recallLoggingConfiguration;

        private readonly Dictionary<Type, int> _eventCounts = new Dictionary<Type, int>();

        protected PipelineObserver(ILogger<T> logger, IRecallLoggingConfiguration recallLoggingConfiguration)
        {
            Guard.AgainstNull(logger, nameof(logger));
            Guard.AgainstNull(recallLoggingConfiguration, nameof(recallLoggingConfiguration));

            _logger = logger;
            _recallLoggingConfiguration = recallLoggingConfiguration;
        }
        
        protected async Task Trace(IPipelineEvent pipelineEvent, string message = "")
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            var type = pipelineEvent.GetType();

            if (!_recallLoggingConfiguration.ShouldLogPipelineEventType(type))
            {
                return;
            }

            Increment(type);

            _logger.LogTrace($"[{type.Name}] : pipeline = {pipelineEvent.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Thread.CurrentThread.ManagedThreadId}");

            await Task.CompletedTask;
        }

        public void Execute(OnAbortPipeline pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAbortPipeline pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnPipelineStarting pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnPipelineStarting pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnPipelineException pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnPipelineException pipelineEvent)
        {
            var type = pipelineEvent.GetType();

            Increment(type);

            var message = $"exception = '{pipelineEvent.Pipeline.Exception?.AllMessages()}'";

            _logger.LogError($"[{type.Name}] : pipeline = {pipelineEvent.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Thread.CurrentThread.ManagedThreadId}");

            await Task.CompletedTask;
        }

        private void Increment(Type type)
        {
            if (!_eventCounts.ContainsKey(type))
            {
                _eventCounts.Add(type, 0);
            }

            _eventCounts[type] += 1;
        }
    }
}