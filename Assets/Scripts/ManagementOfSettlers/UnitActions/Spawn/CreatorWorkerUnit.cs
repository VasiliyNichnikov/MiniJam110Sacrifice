using SettlementObjects.Units;
using UnityEngine;

namespace ManagementOfSettlers.UnitActions.Spawn
{
    public class CreatorWorkerUnit: ICreatorUnit
    {
        private readonly Transform _parentPrefab;
        private readonly GameObject _prefabSettler;

        public CreatorWorkerUnit(Transform parentPrefab, GameObject prefabSettler)
        {
            _parentPrefab = parentPrefab;
            _prefabSettler = prefabSettler;
        }
        
        public ObjectToSelect Create(Vector3 position, Quaternion rotation)
        {
            var newSettler = Object.Instantiate(_prefabSettler, _parentPrefab, false);
            newSettler.transform.position = position;
            newSettler.transform.rotation = rotation;
            return newSettler.GetComponent<ObjectToSelect>();
        }
    }
}