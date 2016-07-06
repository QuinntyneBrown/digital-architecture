using Serilog;
using Serilog.Events;
using SerilogMetrics;
using System.Linq;
using System.Runtime.CompilerServices;
using static DigitalArchitecture.Trace.TracingEvents;

namespace DigitalArchitecture.Trace
{
    public class TraceService: ITraceService
    {
        public ILogger Diagnostics { get; set; }
        public ILogger Analytics { get; set; }
        public ILogger Performance { get; set; }

        public ITimedOperation BeginTimedOperation(string operationInfo = null, [CallerMemberName] string caller = null)        
            => Performance
                .BeginTimedOperation(
                    $"{caller}({operationInfo ?? string.Empty})",
                    completedMessage: CompletedOperationTemplate.Message,
                    levelBeginning: LogEventLevel.Verbose,
                    levelCompleted: LogEventLevel.Information,
                    levelExceeds: LogEventLevel.Verbose);
        
    }

    public static class LoggerExtensions
    {
        public static string EventId { get; set; } = "EventId";

        public static void Event(this ILogger logger, TracingEvent tracingEvent, params object[] properties)
        {
            properties = properties.Concat(new object[] { tracingEvent.EventId }).ToArray();
            logger.Write(tracingEvent.Level, $"{tracingEvent.Message} {{{EventId}}}", properties);
        }
    }
}
