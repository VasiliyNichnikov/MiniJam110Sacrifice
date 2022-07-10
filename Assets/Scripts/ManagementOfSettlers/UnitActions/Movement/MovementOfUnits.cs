using UnityEngine;

namespace ManagementOfSettlers.UnitActions.Movement
{
    public class MovementOfUnits : UnitAction
    {
        // [SerializeField] private BufferOfSelectedObjects _buffer;

        public override void Action(object parameter)
        {
            if (parameter is Vector3 position)
                Move(position);
        }

        /// <summary>
        /// Перемещение выделенных юнитов в заданную точку
        /// </summary>
        /// <param name="position">Заданная точка для перемещения</param>
        private void Move(Vector3 position)
        {
            // if (_buffer.SelectedObjects.Length == 0)
            //     return; // Двигать нечего
            //
            // foreach (var obj in _buffer.SelectedObjects)
            // {
            //     // todo починить
            //      // unit = obj as CanvasScaler.Unit;
            //     // if (unit != null)
            //     // {
            //     //     // unit.Walking(position);
            //     // }
            // }
        }
    }
}