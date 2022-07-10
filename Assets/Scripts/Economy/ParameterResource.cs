using System;
using SettlementObjects.Builders;
using SettlementObjects.Resource;
using UnityEngine;

namespace Economy
{
    [Serializable]
    public class ParameterResource
    {
        public IResource Resource
        {
            get
            {
#if UNITY_EDITOR
                if (_resource != null && (_resource is IResource) == false)
                {
                    throw new Exception("Resource must be a IResource");
                }
#endif
                return _resource as IResource;
            }
        }

        public BaseBuildCollector[] Builders => _builders;
        
        [SerializeField, Header("Постройки, на которых производится выбранный ресурс")]
        private BaseBuildCollector[] _builders;

        [SerializeField, Header("Ресурс производства")] private ScriptableObject _resource;
    }
}