﻿using Economy.Resource;
using SettlementObjects.Units;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public interface IBuilder
    {
        public Vector3 SubscribeToJob(Unit unit);

        public void UnsubscribeToWork(Unit unit);
    }
}