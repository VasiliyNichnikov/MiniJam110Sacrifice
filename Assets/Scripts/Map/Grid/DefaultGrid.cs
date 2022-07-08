using UnityEngine;

namespace Map.Grid
{
    /// <summary>
    /// Сетка по умолчанию
    /// </summary>
    public class DefaultGrid : IGrid
    {
        public Vector2Int Size { get; }
        public Vector2Int SizeCell { get; }
        public ICell[,] Cells { get; }

        public DefaultGrid(Vector2Int size, Vector2Int sizeCell, Vector2 offset)
        {
            Size = size;
            SizeCell = sizeCell;
            Cells = new CalculatorGrid(this, offset).GetArrayGrid();
        }
    }
}