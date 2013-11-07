using System.Globalization;
using System.Threading;
using OpenTable.Umami.Common.Logging;
using System;

namespace TestLog4Net
{
    class Program
    {

        protected static readonly bool UseThreading = true;

        static void Main()
        {
            ILogger log = new Log4NetLogger("TestLog4Net.Program");

            const string publisher = "TestLog4Net";
            const string category = "Main";

            log.LogDebug("This is a Debug log message");
            log.LogDebug(publisher, category, "This is a Debug log message with publisher and category");
            log.LogInfo("This is an info log message");
            log.LogInfo(publisher, category, "This is an info log message with publisher and category");
            log.LogWarning("This is a Warning log message");
            log.LogWarning(publisher, category, "This is a Warning log message with publisher and category");
            log.LogError("This is an Error log message");
            log.LogError(publisher, category, "This is an Error log message with publisher and category");
            log.LogFatal("This is a Fatal log message");
            log.LogFatal(publisher, category, "This is a Fatal log message with publisher and category");

            for (var i = 1; i <= 10; ++i )
            {
                if (UseThreading)
                {
                    var t = new Thread(ProcessAlpha);
                    log.LogDebug("Created thread " + t.ManagedThreadId.ToString(CultureInfo.InvariantCulture));
                    t.Start(i);
                }
                else
                {
                    ProcessAlpha(i);
                }
            }
            
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

        static void ProcessAlpha(object index)
        {
            var a = new Alpha((int) index);
            a.DoAlphaOne();
            a.DoAlphaTwo();
        }
    }
}
