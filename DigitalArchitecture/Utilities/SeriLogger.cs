using Serilog;
using System;

namespace DigitalArchitecture.Utilities
{
    public class SeriLogger : DigitalArchitecture.Utilities.ILogger
    {
        private static volatile Serilog.ILogger _current = null;
        public static Serilog.ILogger Current
        {
            get
            {
                if (_current == null)
                    _current = new LoggerConfiguration()
                        .WriteTo.RollingFile("logfile.txt", retainedFileCountLimit: 2)
                        .CreateLogger();
                return _current;
            }
        }

        public void AddProvider(ILoggerProvider provider)
        {
            throw new NotImplementedException();
        }

        public void Information(string messageTemplate, params object[] propertyValues)
            => SeriLogger.Current.Information(messageTemplate, propertyValues);
    }
}
