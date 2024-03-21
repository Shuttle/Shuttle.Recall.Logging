using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging
{
    public class RecallLoggingBuilder
    {
        private RecallLoggingOptions _recallLoggingOptions = new RecallLoggingOptions();

        public RecallLoggingOptions Options
        {
            get => _recallLoggingOptions;
            set => _recallLoggingOptions = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IServiceCollection Services { get; }

        public RecallLoggingBuilder(IServiceCollection services)
        {
            Guard.AgainstNull(services, nameof(services));

            Services = services;
        }
    }
}