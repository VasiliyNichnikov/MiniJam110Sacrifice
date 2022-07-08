using UnityEngine;

namespace ObjectUnity
{
    public interface IBoundary
    {
        public Vector3 Right { get; }
        public Vector3 Left { get; }
        public Vector3 Forward { get; }
        public Vector3 Back { get; }

        public float LengthX { get; }
        public float LengthZ { get; }
    }
}