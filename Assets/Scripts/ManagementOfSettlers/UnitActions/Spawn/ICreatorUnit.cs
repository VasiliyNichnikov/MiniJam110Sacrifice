using SettlementObjects.Units;
using UnityEngine;

namespace ManagementOfSettlers.UnitActions.Spawn
{
    public interface ICreatorUnit
    {
        public ObjectToSelect Create(Vector3 position, Quaternion rotation);
    }
}