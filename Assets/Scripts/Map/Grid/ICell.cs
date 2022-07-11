using UnityEngine;

namespace Map.Grid
{
    public interface ICell
    {
        public Vector2 Position { get; }
        public Vector2 Size { get; }
        public Vector2 Center { get; }

        public bool IsEnter(Vector2 position);
        public bool IsEnter(Vector3 position);
    }
}