using ClickObjects;
using ManagementOfSettlers.UnitSelection;
using ManagementOfSettlers.UnitSelection.Buffer;
using UnityEngine;

namespace HighlightingSettlementObjects
{
    public class SelectionOfObjects : MonoBehaviour
    {
        [Header("Основная камера"), SerializeField]
        private Camera _camera;

        [Header("Слои земли, на которые можно нажать"), SerializeField]
        private LayerMask _layersGround;
        
        [SerializeField, Header("Буфер всех объектов в игре, с которыми можно взаимодействовать")]
        private BufferOfSelectedObjects _buffer;
        
        private ClickerOnObjects _clicker;
        private GroupManager _group;

        /// <summary>
        /// Выделяет/Убирает выделение с объектов, которые попадают/не попадают в зону панели
        /// </summary>
        /// <param name="start">Начальная точка панели</param>
        /// <param name="end">Конечная точка панели</param>
        public void MarkWithFilters(Vector3 start, Vector3 end)
        {
            _group.EnterGroupWhoInSelectionPanelArea(start, end);
        }
        
        /// <summary>
        /// Отдает команду группе
        /// </summary>
        public void GiveCommandToGroup()
        {
            _group.GiveCommand();
        }
        
        private void Start()
        {
            _clicker = new ClickerOnObjects(_camera, _layersGround);
            _group = new GroupManager(_buffer, _camera, _clicker);
        }
        
    }
}