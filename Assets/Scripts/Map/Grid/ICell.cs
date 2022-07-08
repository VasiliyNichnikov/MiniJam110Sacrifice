using UnityEngine;

namespace Map.Grid
{
    public interface ICell
    {
        public Vector2Int Position { get; }
        public Vector2Int Size { get; }
        public Vector2 Center { get; }
        public Color TestColor { get; }
        
        public bool IsEnter(Vector2 position);
        public bool IsEnter(Vector3 position);
    }
}