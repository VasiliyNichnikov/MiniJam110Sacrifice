using System;
using System.Collections.Generic;
using ClickObjects;
using SettlementObjects.Units;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public class Trees : MonoBehaviour, IBuilder, IClickObject
    {
        [SerializeField, Header("Позиции для поселенцев, где они могут работать")]
        private Transform[] _positionsForSettlers;

        // private List<IObjectToSelect> _workers;
        public bool IsClick => true;
        public bool IsAction => true;

        private int _numberOfJobsOccupied;

        public bool IsJobAvailable()
        {
            return _numberOfJobsOccupied < _positionsForSettlers.Length;
        }

        public Vector3 SubscribeToJob()
        {
            // taskWorker.SubscribeTask();
            var positionWork = _positionsForSettlers[_numberOfJobsOccupied].position;
            positionWork.y = 0.0f;
            _numberOfJobsOccupied++;
            return positionWork;
        }

        public void UnsubscribeToWork()
        {
            _numberOfJobsOccupied--;
            // taskWorker.UnsubscribeToWork();
        }
    }
}