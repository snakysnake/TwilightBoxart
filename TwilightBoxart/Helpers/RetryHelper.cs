using System;
using System.Threading;

namespace KirovAir.Core.Utilities
{
    public class RetryHelper(TimeSpan defaultDelay, int defaultRetries = 3)
    {
        private readonly TimeSpan _defaultDelay = defaultDelay;
        private readonly int _defaultRetries = defaultRetries;

        public void RetryOnException(Action operation)
        {
            RetryOnException(_defaultRetries, _defaultDelay, operation);

        }

        public static void RetryOnException(int times, TimeSpan delay, Action operation)
        {
            var attempts = 0;
            while (true)
            {
                try
                {
                    attempts++;
                    operation();
                    break;
                }
                catch
                {
                    if (attempts == times)
                        throw;

                    Thread.Sleep(delay);
                }
            }
        }
    }
}
