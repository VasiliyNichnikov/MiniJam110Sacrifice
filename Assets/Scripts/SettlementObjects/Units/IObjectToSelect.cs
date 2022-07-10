using UnityEngine;

namespace SettlementObjects.Units
{
    public interface IObjectToSelect
    {
        bool IsSelected { get; }
        bool CheckSelection(Camera camera, Vector3 startSelectionPanel, Vector3 endSelectionPanel);
        void Highlight();
        void CancelSelection();
    }
}