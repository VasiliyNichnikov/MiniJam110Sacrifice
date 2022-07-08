using UnityEngine;

namespace Map.ObjectUnity
{
    public interface IBoundary
    {
        public float MaxX { get; }
        public float MinX { get; }
        public float MaxZ { get; }
        public float MinZ { get; }
        
        public float LengthX { get; }
        public float LengthZ { get; }
    }
}