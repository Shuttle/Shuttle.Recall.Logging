using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging;

public class RecallLogger : IHostedService
{
    private readonly ILogger<RecallLogger> _logger;
    private readonly RecallOptions _recallOptions;

    public RecallLogger(ILogger<RecallLogger> logger, IOptions<RecallOptions> recallOptions)
    {
        _recallOptions = Guard.AgainstNull(Guard.AgainstNull(recallOptions).Value);
        _logger = Guard.AgainstNull(logger);

        _recallOptions.Operation += Operation;
    }

    private Task Operation(OperationEventArgs eventArgs, CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Trace))
        {
            _logger.LogTrace(Guard.AgainstNull(eventArgs).Operation);
        }

        return Task.CompletedTask;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _recallOptions.Operation -= Operation;

        return Task.CompletedTask;
    }
}