﻿using System.Collections.Generic;
using SettlementObjects.Units;
using UnityEngine;

namespace ManagementOfSettlers.UnitSelection.Buffer
{
    public class BufferOfSelectedObjects : MonoBehaviour, IBuffer
    {
        public IEnumerable<ObjectToSelect> SelectedObjects => _selectedObjects.ToArray();
        
        private List<ObjectToSelect> _selectedObjects;

        public void Add(ObjectToSelect selectedObject)
        {
            _selectedObjects.Add(selectedObject);
        }

        public IEnumerable<ObjectToSelect> GetUnits()
        {
            var objectToSelects = new List<ObjectToSelect>();
            foreach (var obj in _selectedObjects)
            {
                if (obj is Unit unit)
                    objectToSelects.Add(unit);
            }

            return objectToSelects.ToArray();
        }

        private void Start()
        {
            _selectedObjects = new List<ObjectToSelect>(FindObjectsOfType<ObjectToSelect>());
        }
    }
}