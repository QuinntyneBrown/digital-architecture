using static Microsoft.Owin.Hosting.WebApp;
using static System.Console;
using static CommandLine.Parser;

namespace DigitalArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new SelfHostOptions();
            Default.ParseArguments(args, options);
            string host = string.IsNullOrEmpty(options.Port) ? "localhost:50225" : $"localhost:{options.Port}";
            host = string.IsNullOrEmpty(options.Host) ? host : options.Host;
            string baseAddress = $"http://{host}/";
            Start<Startup>(url: baseAddress);
            AppActivator.PostStart();
            WriteLine($"Api Hosted at: {baseAddress}");
            ReadLine();
        }
    }
}
