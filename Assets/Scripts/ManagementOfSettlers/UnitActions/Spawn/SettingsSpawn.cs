using UnityEngine;
using UnityEngine.Events;

namespace ManagementOfSettlers.UnitActions.Spawn
{
    public class SettingsSpawn : MonoBehaviour
    {
        [SerializeField, Header("Префаб поселенца, который будет создаваться на спавне")]
        private GameObject _prefabSettler;

        [SerializeField, Header("Место где будут храниться все созданные поселенцы")]
        private Transform _parentSettlers;

        [SerializeField, Header("События, которые вызываются во время создания поселенца")]
        private UnityEvent<ICreatorUnit> _onCreateUnit;

        [SerializeField, Header("ДОБАВЛЕНО ДЛЯ ТЕСТА")]
        private bool _createUnit;
        
        private ICreatorUnit _creator;
        

        private void Start()
        {
            _creator = new CreatorWorkerUnit(_parentSettlers, _prefabSettler);
        }
        
        //todo добавить таймер
        private void Update()
        {
            if (_createUnit)
            {
                _onCreateUnit.Invoke(_creator);
                _createUnit = false;
            }
        }
    }
}