# Recall Logging

```
PM> Install-Package Shuttle.Recall.Logging
```

## Configuration

```c#
services.AddRecallLogging(); // all logging options enabled
```

Specific logging options may be specified:

```c#
services.AddRecallLogging(builder =>
{
	builder.Options.PipelineTypes = new List<string> { "pieline-type-name" };
	builder.Options.PipelineEventTypes = new List<string> { "pieline-event-type-name" };
	builder.Options.AddPipelineType<PipelineType>();
	builder.Options.AddPipelineType(pipelineType);
	builder.Options.AddPipelineEventType<PipelineEventType>();
	builder.Options.AddPipelineEventType(pipelineEventType);
});
```