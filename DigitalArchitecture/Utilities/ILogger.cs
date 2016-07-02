namespace DigitalArchitecture.Utilities
{
    public interface ILogger
    {
        void AddProvider(ILoggerProvider provider);
        void Information(string messageTemplate, params object[] propertyValues);
    }
}
