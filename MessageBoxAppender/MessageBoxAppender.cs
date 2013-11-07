using System;
using System.Diagnostics;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace MessageBoxAppender
{
    public class MessageBoxAppender : AppenderSkeleton
    {
        override protected void Append(LoggingEvent loggingEvent)
        {
            var title = string.Format("{0} {1}",
               loggingEvent.Level.DisplayName,
               loggingEvent.LoggerName);

            var message = string.Format(
               "{0}{1}{1}{2}{1}Domain:{3}{1}(Yes to continue, No to debug)",
               RenderLoggingEvent(loggingEvent),
               Environment.NewLine,
               loggingEvent.LocationInformation.FullInfo,
               loggingEvent.Domain);

            var result = MessageBox.Show(message, title,
               MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                Debugger.Break();
            }
        }
        override protected bool RequiresLayout
        {
            get { return true; }
        }
    }
}
