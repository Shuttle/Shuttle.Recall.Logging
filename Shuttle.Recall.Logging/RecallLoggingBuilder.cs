using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging
{
    public class RecallLoggingBuilder
    {
        private RecallLoggingOptions _recallLoggingOptions = new();

        public RecallLoggingOptions Options
        {
            get => _recallLoggingOptions;
            set => _recallLoggingOptions = Guard.AgainstNull(value);
        }

        public IServiceCollection Services { get; }

        public RecallLoggingBuilder(IServiceCollection services)
        {
            Services = Guard.AgainstNull(services);
        }
    }
}