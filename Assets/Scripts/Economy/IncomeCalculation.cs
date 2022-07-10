using System.Linq;
using ManagementOfSettlers.UnitSelection.Buffer;
using SettlementObjects.Resource;

namespace Economy
{
    public class IncomeCalculation
    {
        private readonly IBuffer _buffer;
        
        public IncomeCalculation(IBuffer buffer)
        {
            _buffer = buffer;
        }

        public int GetIncome(int extracted, IResource resource)
        {
            var units = _buffer.GetUnits();
            var countUnits = units.Count();

            var income = extracted - countUnits * resource.AmountOfFoodConsumedByOneUnit;

            return income;
        }
    }
}