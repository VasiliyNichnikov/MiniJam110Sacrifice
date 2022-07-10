using SettlementObjects.Resource;
using UnityEngine;

namespace Economy.Resource
{
    public abstract class DefaultResource : ScriptableObject, IResource
    {
        public string Name => _name;
        public float CollectionTime => _collectionTime;
        public int Quantity => _quantity;
        public int AmountOfFoodConsumedByOneUnit => _amountOfFoodConsumedByOneUnit;

        [SerializeField, Header("Название ресурса")]
        private string _name;
        
        [SerializeField, Header("Трата времени на один сбор ресурса (В секундах)")]
        private float _collectionTime;

        [SerializeField, Header("Получаемое кол-во ресурса за один сбор")]
        public int _quantity;
        
        [SerializeField, Header("Кол-во, которое потребляет один поселенец")]
        public int _amountOfFoodConsumedByOneUnit;
    }
}