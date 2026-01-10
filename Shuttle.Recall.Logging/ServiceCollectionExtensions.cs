using Microsoft.Extensions.DependencyInjection;

namespace Shuttle.Recall.Logging;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRecallLogging()
        {
            services.AddHostedService<RecallLogger>();

            return services;
        }
    }
}