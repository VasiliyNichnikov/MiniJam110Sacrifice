using System;
using Economy.Resource;
using SettlementObjects.Builders;
using SettlementObjects.Resource;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public BaseBuildCollector[] Builders
        {
            // todo не лучшая реализация + из-за частого вызова FindObjectsOfType
            get
            {
                if (_resource is IMeal)
                    return Object.FindObjectsOfType<Field>();
                if (_resource is IConstruction)
                    return Object.FindObjectsOfType<Trees>();
                throw new Exception("Ошибка, не корректный объект");
            }
        }

        // [SerializeField, Header("Постройки, на которых производится выбранный ресурс")]
        // private BaseBuildCollector[] _builders;

        [SerializeField, Header("Ресурс производства")] private ScriptableObject _resource;
    }
}