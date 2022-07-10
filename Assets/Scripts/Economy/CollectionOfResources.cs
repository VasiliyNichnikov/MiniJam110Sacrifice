using System.Collections;
using System.Linq;
using SettlementObjects.Builders;
using SettlementObjects.Resource;
using Timer;
using UnityEngine;

namespace Economy
{
    public class CollectionOfResources
    {
        private readonly BaseBuildCollector[] _builders;
        private readonly IResource _resource;

        public CollectionOfResources(ParameterResource parameterResource)
        {
            _builders = parameterResource.Builders;
            _resource = parameterResource.Resource;
        }
        
        public IEnumerator RunProfitCheck()
        {
            var timer = new TimerResource(_resource.CollectionTime);
            while (true)
            {
                yield return null;
                if (timer.InProgress == false)
                {
                    yield return timer.Coroutine();
                    var numberOfWorkers = GetNumberOfWorkers();
                    var quantity = _resource.Quantity * numberOfWorkers;
                    ResourceCreditingEvents.UpdateResource(quantity, _resource);
                }
            }
        }

        private int GetNumberOfWorkers()
        {
            return _builders.Sum(construction => construction.NumberOfWorkers);
        }
    }
}