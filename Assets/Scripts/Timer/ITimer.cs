using System;
using System.Collections;

namespace Timer
{
    public interface ITimer
    {
        public bool InProgress { get; }
        public void ResetTimer();
        public IEnumerator Coroutine();
    }
}