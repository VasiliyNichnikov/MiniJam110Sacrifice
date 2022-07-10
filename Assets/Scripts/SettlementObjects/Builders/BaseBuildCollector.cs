using System.Collections;
using ClickObjects;
using SettlementObjects.Errors;
using SettlementObjects.Resource;
using SettlementObjects.Units;
using Timer;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public abstract class BaseBuildCollector : MonoBehaviour, IBuilder, IClickObject
    {
        public bool IsClick => true;
        public bool IsWork => true;

        private IResource Resource
        {
            get
            {
#if UNITY_EDITOR
                if (_resource != null && (_resource is IResource) == false)
                    Debug.LogError("Resource must be a IResource");
#endif
                return _resource as IResource;
            }
        }

        [SerializeField, Header("Позиции для поселенцев, где они могут работать")]
        private Transform[] _positionsForSettlers;

        [SerializeField, Header("Ресурс, который производит данное строение")]
        private ScriptableObject _resource;
        
        private IEnumerator _selectedWork;
        private int _numberOfWorkers;
        private IObjectToSelect[] _occupiedJobs;
        


        public Vector3 SubscribeToJob(Unit unit)
        {
            var positionWork = GetPositionWork(unit);
            positionWork.y = 0.0f;
            return positionWork;
        }
        
        private Vector3 GetPositionWork(Unit unit)
        {
            for (var indexJob = 0; indexJob < _occupiedJobs.Length; indexJob++)
            {
                if (_occupiedJobs[indexJob] == null)
                {
                    _numberOfWorkers++;
                    _occupiedJobs[indexJob] = unit;
                    return _positionsForSettlers[indexJob].position;
                }
            }
            
            throw new AllSeatsAreOccupied();
        }
        
        public void UnsubscribeToWork(Unit unit)
        {
            for (var indexJob = 0; indexJob < _occupiedJobs.Length; indexJob++)
            {
                if (ReferenceEquals(_occupiedJobs[indexJob], unit))
                {
                    _numberOfWorkers--;
                    _occupiedJobs[indexJob] = null;
                    break;
                }
            }
        }
        

        private void Start()
        {
            _occupiedJobs = new IObjectToSelect[_positionsForSettlers.Length];

            if (_selectedWork != null) return;
            _selectedWork = Work();
            StartCoroutine(_selectedWork);
        }

        private IEnumerator Work()
        {
            var timer = new TimerResource(Resource.CollectionTime);
            while (true)
            {
                yield return null;
                if (timer.InProgress == false)
                {
                    yield return timer.Coroutine();
                    var quantity = Resource.Quantity * _numberOfWorkers;
                    ResourceCreditingEvents.UpdateResource(quantity, Resource);
                }
            }
        }
    }
}