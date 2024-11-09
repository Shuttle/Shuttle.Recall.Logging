using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventStoreLogging(this IServiceCollection services, Action<RecallLoggingBuilder>? builder = null)
    {
        var recallLoggingBuilder = new RecallLoggingBuilder(Guard.AgainstNull(services));

        builder?.Invoke(recallLoggingBuilder);

        services.AddOptions<RecallLoggingOptions>().Configure(options =>
        {
            options.PipelineTypes = recallLoggingBuilder.Options.PipelineTypes;
            options.PipelineEventTypes = recallLoggingBuilder.Options.PipelineEventTypes;
            options.Threading = recallLoggingBuilder.Options.Threading;
        });

        services.AddHostedService<EventProcessingPipelineLogger>();
        services.AddHostedService<AssembleEventEnvelopePipelineLogger>();
        services.AddHostedService<EventProcessorStartupPipelineLogger>();
        services.AddHostedService<GetEventEnvelopePipelineLogger>();
        services.AddHostedService<GetEventStreamPipelineLogger>();
        services.AddHostedService<RemoveEventStreamPipelineLogger>();
        services.AddHostedService<SaveEventStreamPipelineLogger>();
        services.AddHostedService<ThreadingLogger>();

        services.AddSingleton<IRecallLoggingConfiguration, RecallLoggingConfiguration>();

        return services;
    }
}