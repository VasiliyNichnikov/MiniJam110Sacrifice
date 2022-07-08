using UnityEngine;

namespace Map.Grid
{
    public interface ICreatorGrid
    {
        public IGrid Create(Vector2Int sizeGrid, Vector2Int sizeCell);
        
        public IGrid Create(Vector2 sizeGrid, Vector2Int sizeCell);
    }
}