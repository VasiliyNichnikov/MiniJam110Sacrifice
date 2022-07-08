using UnityEngine;

namespace Map.ObjectUnity
{
    public class CalculatorBoundary: IBoundary
    {
        public float MaxX { get; }
        public float MinX { get; }
        public float MaxZ { get; }
        public float MinZ { get; }
        public float LengthX { get; }
        public float LengthZ { get; }

        private readonly MeshRenderer _renderer;

        public CalculatorBoundary(MeshRenderer renderer)
        {
            _renderer = renderer;

            var boundsCenter = renderer.bounds.center;
            MaxX = GetMaxX(boundsCenter);
            MinX = GetMinX(boundsCenter);
            MaxZ = GetMaxZ(boundsCenter);
            MinZ = GetMinZ(boundsCenter);

            LengthX = MaxX - MinX;
            LengthZ = MaxZ - MinZ;
        }

        private float GetMaxX(Vector3 boundsCenter)
        {
            var maxX = new Vector3(Mathf.Infinity, boundsCenter.y, boundsCenter.z);
            return _renderer.bounds.ClosestPoint(maxX).x;
        }
        
        private float GetMinX(Vector3 boundsCenter)
        {
            var minX = new Vector3(-Mathf.Infinity, boundsCenter.y, boundsCenter.z);
            return _renderer.bounds.ClosestPoint(minX).x;
        }
        
        private float GetMaxZ(Vector3 boundsCenter)
        {
            var maxZ = new Vector3(boundsCenter.x, boundsCenter.y, Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(maxZ).z;
        }
        
        private float GetMinZ(Vector3 boundsCenter)
        {
            var minZ = new Vector3(boundsCenter.x, boundsCenter.y, -Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(minZ).z;
        }
    }
}