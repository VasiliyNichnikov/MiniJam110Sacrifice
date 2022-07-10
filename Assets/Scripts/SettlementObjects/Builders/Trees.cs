using ClickObjects;
using SettlementObjects.Errors;
using SettlementObjects.Units;
using UnityEngine;

namespace SettlementObjects.Builders
{
    public class Trees : MonoBehaviour, IBuilder, IClickObject
    {
        [SerializeField, Header("Позиции для поселенцев, где они могут работать")]
        private Transform[] _positionsForSettlers;
        
        public bool IsClick => true;
        public bool IsWork => true;
        
        private IObjectToSelect[] _occupiedJobs;
        

        public Vector3 SubscribeToJob(Unit unit)
        {
            var positionWork = GetPositionWork(unit);
            positionWork.y = 0.0f;
            return positionWork;
        }

        public void UnsubscribeToWork(Unit unit)
        {
            for (var indexJob = 0; indexJob < _occupiedJobs.Length; indexJob++)
            {
                if (ReferenceEquals(_occupiedJobs[indexJob], unit))
                {
                    _occupiedJobs[indexJob] = null;
                    break;
                }
            }
        }

        private Vector3 GetPositionWork(Unit unit)
        {
            for (var indexJob = 0; indexJob < _occupiedJobs.Length; indexJob++)
            {
                if (_occupiedJobs[indexJob] == null)
                {
                    _occupiedJobs[indexJob] = unit;
                    return _positionsForSettlers[indexJob].position;
                }
            }

            throw new AllSeatsAreOccupied();
        }
        
        private void Start()
        {
            _occupiedJobs = new IObjectToSelect[_positionsForSettlers.Length];
        }
        
    }
}