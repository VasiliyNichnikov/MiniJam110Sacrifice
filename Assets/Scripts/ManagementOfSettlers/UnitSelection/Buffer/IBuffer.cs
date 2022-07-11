using System.Collections.Generic;
using SettlementObjects.Units;

namespace ManagementOfSettlers.UnitSelection.Buffer
{
    public interface IBuffer
    {
        public IEnumerable<ObjectToSelect> SelectedObjects { get; }

        public IEnumerable<ObjectToSelect> GetUnits();

        public void Add(ObjectToSelect selectedObject);
    }
}