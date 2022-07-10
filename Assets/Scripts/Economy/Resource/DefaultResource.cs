using UnityEngine;

namespace Economy.Resource
{
    public abstract class DefaultResource : ScriptableObject, IResource
    {
        public float CollectionTime => _collectionTime;
        public int Quantity => _quantity;

        [SerializeField, Header("Трата времени на один сбор ресурса (В секундах)")]
        private float _collectionTime;

        [SerializeField, Header("Получаемое кол-во ресурса за один сбор")]
        public int _quantity;
    }
}