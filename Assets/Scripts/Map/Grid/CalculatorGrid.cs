using UnityEngine;

namespace Map.Grid
{
    /// <summary>
    /// Создает массив ячеек по заданным параметрам сетки
    /// </summary>
    public class CalculatorGrid
    {
        private readonly IGrid _grid;

        public CalculatorGrid(IGrid grid)
        {
            _grid = grid;
        }

        public ICell[,] GetArrayGrid()
        {
            var numberX = _grid.Size.x / _grid.SizeCell.x;
            var numberY = _grid.Size.y / _grid.SizeCell.y;

            var cells = new ICell[numberX, numberY];
            for(var y = 0; y < numberY; y++)
            {
                for(var x = 0; x < numberX; x++)
                {
                    var position = new Vector2Int(y, x) * _grid.SizeCell;
                    cells[y, x] = new DefaultCell(position: position, size: _grid.SizeCell);
                }
            }

            return cells;
        }
    }
}