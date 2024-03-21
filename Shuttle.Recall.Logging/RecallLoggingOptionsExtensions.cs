using System;
using Shuttle.Core.Contract;

namespace Shuttle.Recall.Logging
{
    public static class RecallLoggingOptionsExtensions
    {
        public static RecallLoggingOptions AddPipelineType<T>(
            this RecallLoggingOptions recallLoggingOptions)
        {
            return recallLoggingOptions.AddPipelineType(typeof(T));
        }

        public static RecallLoggingOptions AddPipelineType(this RecallLoggingOptions recallLoggingOptions, Type type)
        {
            Guard.AgainstNull(type, nameof(type));

            if (recallLoggingOptions.PipelineTypes == null)
            {
                throw new InvalidOperationException(Resources.PipelineTypesNullException);
            }

            recallLoggingOptions.PipelineTypes.Add(type.AssemblyQualifiedName);

            return recallLoggingOptions;
        }

        public static RecallLoggingOptions AddPipelineEventType<T>(this RecallLoggingOptions recallLoggingOptions)
        {
            return recallLoggingOptions.AddPipelineEventType(typeof(T));
        }

        public static RecallLoggingOptions AddPipelineEventType(this RecallLoggingOptions recallLoggingOptions, Type type)
        {
            Guard.AgainstNull(type, nameof(type));

            if (recallLoggingOptions.PipelineEventTypes == null)
            {
                throw new InvalidOperationException(Resources.PipelineTypesNullException);
            }

            recallLoggingOptions.PipelineEventTypes.Add(type.AssemblyQualifiedName);

            return recallLoggingOptions;
        }

    }
}