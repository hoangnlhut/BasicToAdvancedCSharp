using Microsoft.Extensions.Logging;

namespace Part24_Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ILoggerFactory factory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Debug);
                    // with this filter it will take effect than above
                    builder.AddFilter(level => level == LogLevel.Warning || level == LogLevel.Information);
                }
                );

            #region we can create multiple category name for logging
            ILogger logger = factory.CreateLogger("Program");
            ILogger logger2 = factory.CreateLogger("Program2");

            //logger.LogInformation("Hello World! Logging is {Description}.", "fun");
            //logger.LogInformation("Hello World! Logging is from logger");
            //logger2.LogInformation("Hello World! Logging is from logger2");
            #endregion

            #region LogLevel : default is Information -> If we want to set defaul use SetMinimumLevel() method ant it only display warning and information due to filter of line 15

            logger.LogTrace("Logging Trace");
            logger.LogDebug("Logging Debug");
            logger.LogInformation("Logging Infomation");
            logger.LogWarning("Logging Warning");
            logger.LogError("Logging Error");
            logger.LogCritical("Logging Critical");

            //Log None is the last value in log Level 
            #endregion

            #region IsEnable(LogLevel)
            var logLevel = LogLevel.Warning;
            if (logger.IsEnabled(logLevel))
            {
                Console.WriteLine($"{logLevel} is enabled");
            }
            #endregion

            #region message template
            var a = "ABC";

            logger.LogInformation("Logging Infomation with message template {a}", a);

            #endregion

            #region message template formatting
            double b = 10.234;

            logger.LogInformation("Logging Infomation with message template formatting {b:E}", b);

            #endregion
        }
    }
}
