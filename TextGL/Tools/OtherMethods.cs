using System;
using System.Diagnostics;

namespace TextGL.Tools
{
    public static class OtherMethods
    {
        public static long MeasurePerformance(Action function)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            function();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}