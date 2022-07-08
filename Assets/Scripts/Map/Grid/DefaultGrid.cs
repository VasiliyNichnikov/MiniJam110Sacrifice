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
        private readonly Vector2 _offset;

        public DefaultGrid(Vector2Int size, Vector2Int sizeCell, Vector2 offset)
        {
            Size = size;
            SizeCell = sizeCell;
            Cells = new CalculatorGrid(this, offset).GetArrayGrid();
            _offset = offset;
        }

        public ICell[] GetPointsInZoneBySquare(Vector2 leftDown, Vector2 rightUp)
        {
            var rightUpCell = GetIndexCellByPosition(rightUp);
            var leftDownCell = GetIndexCellByPosition(leftDown);

            var sizeX = Mathf.Abs(leftDownCell.x - rightUpCell.x) + 1;
            var sizeY = Mathf.Abs(leftDownCell.y - rightUpCell.y) + 1;

            var cells = new ICell[sizeX * sizeY];
            
            var index = 0;

            var rows = Cells.GetUpperBound(0) + 1; 
            var columns = Cells.Length / rows;
            
            for (var x = 0; x < sizeX; x++)
            {
                for(var y = 0; y < sizeY; y++)
                {
                    var indexX = leftDownCell.x + x;
                    var indexY = leftDownCell.y + y;
                    
                    if (indexX >= rows || indexY >= columns) continue;
                    
                    cells[index] = Cells[indexX, indexY];
                    index++;
                }
            }
            return cells;
        }

        private (int x, int y) GetIndexCellByPosition(Vector2 position)
        {
            position -= _offset;
            MonoBehaviour.print($"X: {Mathf.Abs(position.x) / SizeCell.x} Y: {Mathf.Abs(position.y) / SizeCell.y}");
            var x = (int)Mathf.Floor(Mathf.Abs(position.x) / SizeCell.x);
            var y = (int)Mathf.Floor(Mathf.Abs(position.y) / SizeCell.y);
            return (x, y);
        }
    }
}