using Units;
using UnityEngine;

namespace SettlementObjects.Units
{
    public interface IObjectToSelect
    {
        TypesOfObjects TypeObject { get; }
        bool IsSelected { get; }
        bool CheckSelection(Camera camera, Vector3 startSelectionPanel, Vector3 endSelectionPanel);
        void Highlight();
        void CancelSelection();
    }
}