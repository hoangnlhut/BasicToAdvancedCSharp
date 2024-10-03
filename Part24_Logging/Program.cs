using Microsoft.Extensions.Logging;

namespace Part24_Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Program");
            logger.LogInformation("Hello World! Logging is {Description}.", "fun");
        }
    }
}
