using Units;
using UnityEngine;
using Utils.Selection;

namespace SettlementObjects.Units
{
    public abstract class ObjectToSelect : MonoBehaviour, IObjectToSelect
    {
        public Transform ThisTransform { get; private set; }

        [SerializeField, Header("Объект, показывающий игроку, что юнит выделен")]
        private GameObject _selector;
        public virtual TypesOfObjects TypeObject { get; }
        public bool IsSelected { get; private set; }

        public bool CheckSelection(Camera camera, Vector3 startSelectionPanel, Vector3 endSelectionPanel)
        {
            return SelectionUtilities.CheckRectangleHit(camera, ThisTransform.position, 
                startSelectionPanel, endSelectionPanel);
        }

        public void Highlight()
        {
            IsSelected = true;
            SelectionUtilities.ChangeStateSelector(_selector, true);
        }

        public void CancelSelection()
        {
            IsSelected = false;
            SelectionUtilities.ChangeStateSelector(_selector, false);
        }
        
        public virtual void Start()
        {
            SelectionUtilities.ChangeStateSelector(_selector, false);
            ThisTransform = transform;
        }
    }
}