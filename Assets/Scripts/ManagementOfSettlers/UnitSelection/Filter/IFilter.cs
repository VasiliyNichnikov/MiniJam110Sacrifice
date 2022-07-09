using SettlementObjects.Units;

namespace ManagementOfSettlers.UnitSelection.Filter
{
    public interface IFilter
    {
        public bool IsFirstSelectedObject { get; }
        public void SelectFirstObject(IObjectToSelect objectToSelect);
        public void RemovingSelectionFromFirstObject(IObjectToSelect removedSelection);
        public bool CheckTypeOfFirstObjectAndSelectedOne(IObjectToSelect selectedOne);
    }
}