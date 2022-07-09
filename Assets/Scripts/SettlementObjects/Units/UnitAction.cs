using UnityEngine;

namespace SettlementObjects.Units
{
    public class UnitAction
    {
        public Vector3 PointOfMovement { get; private set; }
        private Vector3 _clickingPosition;
        // private readonly Group _group;

        // public UnitAction(Group group)
        // {
        //      _group = group;
        // }
        
        /// <summary>
        /// Обновляет позицию движения
        /// </summary>
        /// <returns>Возвращает тип объекта в который попал</returns>
        // public TypesOfHits UpdatePointOfMovement(Vector3 positionNow)
        // {
        //     var clicking = _group.Clicker.GetInformationAboutClicking();
        //     _clickingPosition = clicking.position;
        //     PointOfMovement = _group.Center - positionNow + _clickingPosition;
        //     return clicking.hit;
        // }
    }
}