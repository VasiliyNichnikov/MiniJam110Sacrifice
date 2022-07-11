using UnityEngine;
using Utils.Selection;

namespace SettlementObjects.Units
{
    public abstract class ObjectToSelect : MonoBehaviour, IObjectToSelect
    {
        protected Transform ThisTransform { get; private set; }
        
        [SerializeField, Header("Объект, показывающий игроку, что юнит выделен")]
        private GameObject _selector;
        private bool _notHighlight;
        
        public bool CheckSelection(Camera camera, Vector3 startSelectionPanel, Vector3 endSelectionPanel)
        {
            return SelectionUtilities.CheckRectangleHit(camera, ThisTransform.position, 
                startSelectionPanel, endSelectionPanel);
        }

        public void Highlight()
        {
            if(_notHighlight)
                return;
            
            SelectionUtilities.ChangeStateSelector(_selector, true);
        }

        public void CancelSelection()
        {
            if(_notHighlight)
                return;
            
            SelectionUtilities.ChangeStateSelector(_selector, false);
        }

        public void TurnOffSelection()
        {
            CancelSelection();
            _notHighlight = true;
        }

        public virtual void Start()
        {
            SelectionUtilities.ChangeStateSelector(_selector, false);
            ThisTransform = transform;
        }
    }
}