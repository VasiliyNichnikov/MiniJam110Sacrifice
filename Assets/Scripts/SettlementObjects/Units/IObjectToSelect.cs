using UnityEngine;

namespace SettlementObjects.Units
{
    public interface IObjectToSelect
    {
        public bool CheckSelection(Camera camera, Vector3 startSelectionPanel, Vector3 endSelectionPanel);
        public void Highlight();
        public void CancelSelection();
        public void TurnOffSelection();
    }
}