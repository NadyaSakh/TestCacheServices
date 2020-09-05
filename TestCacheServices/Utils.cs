using System;

namespace TestCacheServices
{
    class Utils
    {
        public static string showEllapsedTime(TimeSpan ts)
        {
            // Format and display the TimeSpan value. (до сотых секунды)
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            return elapsedTime;
        }
    }
}
