using System.Collections.Generic;
using SettlementObjects.Units;
using UnityEngine;

namespace ManagementOfSettlers.UnitSelection.Buffer
{
    public class BufferOfSelectedObjects : MonoBehaviour, IBuffer
    {
        public IEnumerable<ObjectToSelect> SelectedObjects => _selectedObjects.ToArray();
        
        [SerializeField, Header("Стартовые постройки и юниты, с которыми можно взаимодействовать")]
        private List<ObjectToSelect> _selectedObjects;
        
        public void Add(ObjectToSelect selectedObject)
        {
            _selectedObjects.Add(selectedObject);
        }

        public void Clear()
        {
            _selectedObjects.Clear();
        }
    }
}