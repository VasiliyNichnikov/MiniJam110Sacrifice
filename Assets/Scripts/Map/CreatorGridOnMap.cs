using Map.Grid;
using Map.ObjectUnity;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CreatorGridOnMap : MonoBehaviour
    {
        [SerializeField, Header("Размер ячейки в сетке")]
        private Vector2Int _sizeCell;

        [SerializeField] private Transform _testCube;
        private CalculatorBoundary _boundary;
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

        private void OnDrawGizmos()
        {
            if (_grid == null || _boundary == null)
            {
                return;
            }

            foreach (var cell in _grid.Cells)
            {
                var position = new Vector3(cell.Position.x, 0, cell.Position.y);
                var size = new Vector3(cell.Size.x, 0, cell.Size.y);
                var center = new Vector3(cell.Center.x, 0, cell.Center.y);

                Gizmos.color = cell.IsEnter(_testCube.position) ? Color.red : cell.TestColor;
                Gizmos.DrawCube(center, size);

                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(position, 0.1f);

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(center, 0.1f);
            }
        }
    }
}