using System;
using System.Collections.Generic;
using ClickObjects;
using ManagementOfSettlers.UnitSelection.Buffer;
using ManagementOfSettlers.UnitSelection.Filter;
using SettlementObjects.Units;
using UnityEngine;
using Utils.Selection;

namespace ManagementOfSettlers.UnitSelection
{
    /// <summary>
    /// Создает группу, с выбранными объектами.
    /// </summary>
    public class GroupManager
    {
        private readonly IFilter _filter;
        private readonly IBuffer _buffer;
        private readonly Camera _camera;
        private readonly ClickerOnObjects _clicker;
        private readonly List<IObjectToSelect> _selectedObjects;
        
        public GroupManager(IBuffer buffer, Camera camera, ClickerOnObjects clicker)
        {
            _camera = camera;
            _buffer = buffer;
            _clicker = clicker;
            _selectedObjects = new List<IObjectToSelect>();
            _filter = new FilterSelectedObjects();
        }
        
        /// <summary>
        /// Добавление/Удаление объектов из группы, котоыре попадают/не попадают в зону выделения
        /// </summary>
        /// <param name="startSelectionPanel"></param>
        /// <param name="endSelectionPanel"></param>
        public void EnterGroupWhoInSelectionPanelArea(Vector3 startSelectionPanel, Vector3 endSelectionPanel)
        {
            foreach (var selectedObject in _buffer.SelectedObjects)
            {
                if (selectedObject.CheckSelection(_camera, startSelectionPanel, endSelectionPanel) && _selectedObjects.Contains(selectedObject) == false)
                    Selection(selectedObject);
                else if (selectedObject.CheckSelection(_camera, startSelectionPanel, endSelectionPanel) == false && _selectedObjects.Contains(selectedObject))
                    RemoveSelection(selectedObject);
            }
        }

        /// <summary>
        /// Передает выбранной группе контрольную точку
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GiveCommand()
        {
            var clicking = _clicker.GetInformationAboutClicking();
            var targetPositionList = GroupDistributionAlgorithm.GetPositionListAround(clicking.position,
                new[] {1f, 2.5f, 4f},
                new[] {5, 20, 40});
            var targetPositionListIndex = 0;
            foreach (var obj in _selectedObjects)
            {
                if (obj is Unit unit)
                {
                    if (unit == null) throw new Exception("Unit must not be null"); // todo создать ошибку
                    var newPosition = (clicking.hit, targetPositionList[targetPositionListIndex]);
                    unit.SetClick(newPosition);
                    targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
                }
            }
        }
        
        
        private void Selection(IObjectToSelect selectedObject)
        {
            switch (_filter.IsFirstSelectedObject)
            {
                case false:
                    _filter.SelectFirstObject(selectedObject);
                    break;
                case true when _filter.CheckTypeOfFirstObjectAndSelectedOne(selectedObject):
                    _selectedObjects.Add(selectedObject);
                    selectedObject.Highlight();
                    break;
            }
        }
    
        private void RemoveSelection(IObjectToSelect selectedObject)
        {
            if (_filter.IsFirstSelectedObject)
                _filter.RemovingSelectionFromFirstObject(selectedObject);
            
            _selectedObjects.Remove(selectedObject);
            selectedObject.CancelSelection();
        }
    }
}