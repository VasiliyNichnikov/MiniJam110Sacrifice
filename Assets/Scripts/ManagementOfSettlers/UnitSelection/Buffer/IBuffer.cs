using System.Collections.Generic;
using SettlementObjects.Units;

namespace ManagementOfSettlers.UnitSelection.Buffer
{
    public interface IBuffer
    {
        public IEnumerable<ObjectToSelect> SelectedObjects { get; }
        public void Add(ObjectToSelect selectedObject);
        public void Clear();
    }
}