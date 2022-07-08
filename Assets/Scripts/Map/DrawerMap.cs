using Map.Grid;
using UnityEngine;

namespace Map
{
    public class DrawerMap: MonoBehaviour
    {
        [SerializeField] private Vector2Int _sizeGrid;
        [SerializeField] private Vector2Int _sizeCell;
        [SerializeField] private Transform _testCube;
        
        private IGrid _grid;
        
        private void Start()
        {
            _grid = new DefaultGrid(size: _sizeGrid, sizeCell: _sizeCell);
        }

        private void OnDrawGizmos()
        {
            if (_grid == null)
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