using Map.Grid;
using ObjectUnity;
using UnityEngine;

namespace Map
{
    /// <summary>
    /// Создает сетку карты, на выбранном объекте
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class CreatorGridOnMap : MonoBehaviour
    {
        [SerializeField, Header("Размер ячейки в сетке")]
        private Vector2Int _sizeCell;
        
        private IBoundary _boundary;
        private IGrid _grid;
        
        private void Start()
        {
            var renderer = GetComponent<MeshRenderer>();
            _boundary = new CalculatorBoundary(renderer);
            var sizeGrid = new Vector2(_boundary.LengthX, _boundary.LengthZ);
            var offset = new Vector2(transform.position.x - _boundary.LengthX / 2,
                transform.position.z - _boundary.LengthZ / 2);

            _grid = new CreatorDefaultGrid(offsetGrid: offset).Create(sizeGrid, _sizeCell);
        }
    }
}