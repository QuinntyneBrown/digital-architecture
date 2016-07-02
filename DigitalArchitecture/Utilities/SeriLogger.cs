using Serilog;
using System;

namespace DigitalArchitecture.Utilities
{
    public class SeriLogger : DigitalArchitecture.Utilities.ILogger
    {
        public SeriLogger()
        {
            Serilog.ILogger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger = logger;
        }

        public void AddProvider(ILoggerProvider provider)
        {
            throw new NotImplementedException();
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            Log.Information(messageTemplate, propertyValues);
        }
    }
}
