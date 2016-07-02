﻿using Serilog;
using Serilog.Events;
using SerilogMetrics;
using System.Linq;
using System.Runtime.CompilerServices;
using static DigitalArchitecture.Trace.TracingEvents;

namespace DigitalArchitecture.Trace
{
    public static class DigitalArchitectureTrace
    {
        public static ILogger Diagnostics;
        public static ILogger Analytics;
        public static ILogger Performance;
        public const string EventId = "EventId";

        public static void Event(this ILogger logger, TracingEvent tracingEvent, params object[] properties)
        {
            properties = properties.Concat(new object[] { tracingEvent.EventId }).ToArray();
            logger.Write(tracingEvent.Level, $"{tracingEvent.Message} {{{EventId}}}", properties);
        }

        public static ITimedOperation BeginTimedOperation(string operationInfo = null, [CallerMemberName] string caller = null)        
            => Performance
                .BeginTimedOperation(
                    $"{caller}({operationInfo ?? string.Empty})",
                    completedMessage: ClientError.Message,
                    levelBeginning: LogEventLevel.Verbose,
                    levelCompleted: LogEventLevel.Information,
                    levelExceeds: LogEventLevel.Verbose);
        
    }
}
