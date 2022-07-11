using System;
using System.Collections;
using UnityEngine;

namespace Timer
{
    public class TimerResource : ITimer
    {
        public bool InProgress { get; private set; }
        
        private readonly float _collectionTime;

        public TimerResource(float collectionTime)
        {
            _collectionTime = collectionTime;
        }

        public IEnumerator Coroutine()
        {
            InProgress = true;
            var timeLeft = _collectionTime;
            while (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                yield return null;
            }
            InProgress = false;
        }
    }
}