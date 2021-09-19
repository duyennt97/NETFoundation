using log4net;

namespace BookStoreCommon
{
    public static class LogService
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogCurrentMethod()
        {
            Log.Info($"Executing method: {(new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name}");
        }
    }
}
