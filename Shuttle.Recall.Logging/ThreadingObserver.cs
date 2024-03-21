using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Threading;

namespace Shuttle.Recall.Logging
{
    public class ThreadingObserver :
        IPipelineObserver<OnAfterConfigureThreadPools>,
        IDisposable
    {
        private readonly ILogger<ThreadingLogger> _logger;
        private readonly List<IProcessorThreadPool> _wiredProcessorThreadPools = new List<IProcessorThreadPool>();
        private readonly List<ProcessorThread> _wiredProcessorThreads = new List<ProcessorThread>();

        public ThreadingObserver(ILogger<ThreadingLogger> logger)
        {
            _logger = Guard.AgainstNull(logger, nameof(logger));
        }

        public void Dispose()
        {
            _wiredProcessorThreads.ForEach(item =>
            {
                item.ProcessorException -= OnProcessorException;
                item.ProcessorExecuting -= OnProcessorExecuting;
                item.ProcessorThreadActive -= OnProcessorThreadActive;
                item.ProcessorThreadStarting -= OnProcessorThreadStarting;
                item.ProcessorThreadStopped -= OnProcessorThreadStopped;
                item.ProcessorThreadStopping -= OnProcessorThreadStopping;
                item.ProcessorThreadOperationCanceled -= OnProcessorThreadOperationCanceled;
            });

            _wiredProcessorThreadPools.ForEach(item => item.ProcessorThreadCreated -= OnProcessorThreadCreated);
        }

        public void Execute(OnAfterConfigureThreadPools pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterConfigureThreadPools pipelineEvent)
        {
            Wire(pipelineEvent.Pipeline.State.Get<IProcessorThreadPool>("EventProcessorThreadPool"));

            await Task.CompletedTask;
        }

        private void OnProcessorException(object sender, ProcessorThreadExceptionEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorException] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId} / exception = '{e.Exception}'");
        }

        private void OnProcessorExecuting(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorExecuting] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadActive(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorThreadActive] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadCreated(object sender, ProcessorThreadCreatedEventArgs e)
        {
            _wiredProcessorThreads.Add(e.ProcessorThread);

            e.ProcessorThread.ProcessorException += OnProcessorException;
            e.ProcessorThread.ProcessorExecuting += OnProcessorExecuting;
            e.ProcessorThread.ProcessorThreadActive += OnProcessorThreadActive;
            e.ProcessorThread.ProcessorThreadStarting += OnProcessorThreadStarting;
            e.ProcessorThread.ProcessorThreadStopped += OnProcessorThreadStopped;
            e.ProcessorThread.ProcessorThreadStopping += OnProcessorThreadStopping;
            e.ProcessorThread.ProcessorThreadOperationCanceled += OnProcessorThreadOperationCanceled;
        }

        private void OnProcessorThreadOperationCanceled(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorThreadOperationCanceled] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadStarting(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorThreadStarting] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadStopped(object sender, ProcessorThreadStoppedEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorThreadStopped] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId} / aborted = '{e.Aborted}'");
        }

        private void OnProcessorThreadStopping(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"[ProcessorThreadStopping] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void Wire(IProcessorThreadPool? processorThreadPool)
        {
            if (processorThreadPool == null)
            {
                return;
            }

            _wiredProcessorThreadPools.Add(processorThreadPool);

            processorThreadPool.ProcessorThreadCreated += OnProcessorThreadCreated;
        }
    }
}