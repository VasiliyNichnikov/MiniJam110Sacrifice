using System;
using ClickObjects;
using SettlementObjects.Units;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public class Altar: MonoBehaviour, IBuilder, IClickObject
    {
        public bool IsClick => true;
        public bool IsWork => true;
        public int NumberOfWorkers => throw new Exception("Данный параметр не используется");

        [SerializeField, Header("Центр алтаря")]
        private Transform _centerAltar;
        
        public Vector3 SubscribeToJob(Unit unit)
        {
            var positionCenter = _centerAltar.position;
            positionCenter.y = 0.0f;
            return positionCenter;
        }

        public void UnsubscribeToWork(Unit unit)
        {
        }
    }
}