using System;
using SettlementObjects.Units;

namespace ManagementOfSettlers.UnitSelection.Filter
{
    public class FilterSelectedObjects : IFilter
    {
        public bool IsFirstSelectedObject => _firstSelectedObject != null;
        private IObjectToSelect _firstSelectedObject;


        public void SelectFirstObject(IObjectToSelect objectToSelect)
        {
            _firstSelectedObject ??= objectToSelect;
        }

        public void RemovingSelectionFromFirstObject(IObjectToSelect removedSelection)
        {
            if (_firstSelectedObject != null && _firstSelectedObject == removedSelection)
                _firstSelectedObject = null;
        }

        public bool CheckTypeOfFirstObjectAndSelectedOne(IObjectToSelect selectedOne)
        {
            if (_firstSelectedObject == null)
                throw new Exception("The first filter object should be");
            return selectedOne.TypeObject == _firstSelectedObject.TypeObject;
        }
    }
}