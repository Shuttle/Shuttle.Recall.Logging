using Microsoft.Extensions.Logging;

namespace Shuttle.Recall.Logging;

public class TypeLoggingOptions
{
    public string Type { get; set; } = string.Empty;
    public LogLevel? LogLevel { get; set; }
}