using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Loger
{
    public static class Log
    {
        private static ILogger logger;
        static void LogerCreate()
        {
            using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);

                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = false;
                    options.SingleLine = true;
                });
            });
            logger = loggerFactory.CreateLogger("");
        }
        public static void LogInfo(string message)
        {
            LogerCreate();
            logger.LogInformation(message);
        }

        public static void LogError(string message)
        {
            LogerCreate();
            logger.LogError(message);
        }

        public static void LogDebug(string message)
        {
            LogerCreate();
            logger.LogDebug(message);
        }
    }
}
