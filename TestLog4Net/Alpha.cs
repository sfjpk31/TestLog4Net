using System.Globalization;
using OpenTable.Umami.Common.Logging;

namespace TestLog4Net
{
    public class Alpha
    {
        protected static readonly ILogger Log = new Log4NetLogger("TestLog4Net.Alpha");

        private const string Publisher = "TestLog4Net";
        private const string Category = "Alpha";                                     

        public Alpha(int index)
        {
            Index = index;
        }

        public int Index { get; set; }

        public void DoAlphaOne()
        {
            Log.LogDebug("In DoAlphaOne Index = " + Index.ToString(CultureInfo.InvariantCulture));
            Log.LogDebug(Publisher, Category, "In DoAlphaOne Index = " + Index.ToString(CultureInfo.InvariantCulture));
        }

        public void DoAlphaTwo()
        {
            Log.LogDebug("In DoAlphaTwo Index = " + Index.ToString(CultureInfo.InvariantCulture));
            Log.LogDebug(Publisher, Category, "In DoAlphaTwo Index = " + Index.ToString(CultureInfo.InvariantCulture));
        }
    }
}
