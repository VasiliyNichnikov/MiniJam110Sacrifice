using UnityEngine;

namespace Map.Grid
{
    public interface IGrid
    {
        public Vector2Int Size { get; }
        public Vector2Int SizeCell { get; }
        public ICell[,] Cells { get; }
    }
}