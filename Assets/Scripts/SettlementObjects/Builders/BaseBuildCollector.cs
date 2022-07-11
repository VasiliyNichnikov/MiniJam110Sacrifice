using ClickObjects;
using SettlementObjects.Errors;
using SettlementObjects.Units;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public abstract class BaseBuildCollector : MonoBehaviour, IBuilder, IClickObject
    {
        public bool IsClick => true;
        public bool IsWork => true;
        public int NumberOfWorkers { get; private set; }

        [SerializeField, Header("Позиции для поселенцев, где они могут работать")]
        private Transform[] _positionsForSettlers;
        
        private IObjectToSelect[] _occupiedJobs;
        
        
        public Vector3 SubscribeToJob(Unit unit)
        {
            var positionWork = GetPositionWork(unit);
            positionWork.y = 0.0f;
            return positionWork;
        }
        
        private Vector3 GetPositionWork(Unit unit)
        {
            if(NumberOfWorkers == _occupiedJobs.Length)
                throw new AllSeatsAreOccupied();
            
            for (var indexJob = 0; indexJob < _occupiedJobs.Length; indexJob++)
            {
                if (_occupiedJobs[indexJob] == null)
                {
                    NumberOfWorkers++;
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
                    NumberOfWorkers--;
                    _occupiedJobs[indexJob] = null;
                    break;
                }
            }
        }
        

        private void Start()
        {
            NumberOfWorkers = 0;
            _occupiedJobs = new IObjectToSelect[_positionsForSettlers.Length];
        }
    }
}