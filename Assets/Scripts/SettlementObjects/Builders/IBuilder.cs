using UnityEngine;

namespace SettlementObjects.Builders
{
    public interface IBuilder
    {
        public bool IsJobAvailable();

        public Vector3 SubscribeToJob();

        public void UnsubscribeToWork();
    }
}