using Serilog.Events;

namespace DigitalArchitecture.Trace
{
    public static class TracingEvents
    {
        public static readonly TracingEvent ClientError = new TracingEvent
        {
            Message = "{ErrorMessage}, {StackTrace}",
            EventId = 6,
            Level = LogEventLevel.Error
        };
    }
}
