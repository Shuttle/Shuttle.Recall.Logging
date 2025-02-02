using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Threading;

namespace Shuttle.Recall.Logging;

public class ThreadingObserver : IPipelineObserver<OnAfterConfigureThreadPools>, IDisposable
{
    private readonly ILogger<ThreadingLogger> _logger;
    private readonly List<IProcessorThreadPool> _wiredProcessorThreadPools = new();
    private readonly List<ProcessorThread> _wiredProcessorThreads = new();

    public ThreadingObserver(ILogger<ThreadingLogger> logger)
    {
        _logger = Guard.AgainstNull(logger);
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

    public async Task ExecuteAsync(IPipelineContext<OnAfterConfigureThreadPools> pipelineContext)
    {
        Wire(pipelineContext.Pipeline.State.Get<IProcessorThreadPool>("EventProcessorThreadPool"));

        await Task.CompletedTask;
    }

    private static string GetProcessorFullName(object? sender)
    {
        var processorThread = sender as ProcessorThread;

        if (processorThread == null)
        {
            return "(sender != ProcessorThread)";
        }

        return processorThread.Processor.GetType().FullName ?? processorThread.Processor.GetType().Name;
    }

    private void OnProcessorException(object? sender, ProcessorThreadExceptionEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorException] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId} / exception = '{e.Exception}'");
    }

    private void OnProcessorExecuting(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorExecuting] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
    }

    private void OnProcessorThreadActive(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorThreadActive] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
    }

    private void OnProcessorThreadCreated(object? sender, ProcessorThreadCreatedEventArgs e)
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

    private void OnProcessorThreadOperationCanceled(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorThreadOperationCanceled] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
    }

    private void OnProcessorThreadStarting(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorThreadStarting] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
    }

    private void OnProcessorThreadStopped(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorThreadStopped] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
    }

    private void OnProcessorThreadStopping(object? sender, ProcessorThreadEventArgs e)
    {
        _logger.LogTrace($@"[ProcessorThreadStopping] : name = '{e.Name}' / processor = {GetProcessorFullName(sender)} / managed thread id = {e.ManagedThreadId}");
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