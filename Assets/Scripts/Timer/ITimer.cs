using System.Collections;

namespace Timer
{
    public interface ITimer
    {
        public bool InProgress { get; }
        public IEnumerator Coroutine();
    }
}