using UnityEngine;

namespace Utils.Boundary
{
    public class CalculatorBoundary: IBoundary
    {
        public Vector3 Right { get; }
        public Vector3 Left { get; }
        public Vector3 Forward { get; }
        public Vector3 Back { get; }
        public float LengthX { get; }
        public float LengthZ { get; }

        private readonly MeshRenderer _renderer;

        public CalculatorBoundary(MeshRenderer renderer)
        {
            _renderer = renderer;

            var boundsCenter = renderer.bounds.center;
            Right = GetMaxX(boundsCenter);
            Left = GetMinX(boundsCenter);
            Forward = GetMaxZ(boundsCenter);
            Back = GetMinZ(boundsCenter);

            LengthX = Right.x - Left.x;
            LengthZ = Forward.z - Back.z;
        }

        private Vector3 GetMaxX(Vector3 boundsCenter)
        {
            var maxX = new Vector3(Mathf.Infinity, boundsCenter.y, boundsCenter.z);
            return _renderer.bounds.ClosestPoint(maxX);
        }
        
        private Vector3 GetMinX(Vector3 boundsCenter)
        {
            var minX = new Vector3(-Mathf.Infinity, boundsCenter.y, boundsCenter.z);
            return _renderer.bounds.ClosestPoint(minX);
        }
        
        private Vector3 GetMaxZ(Vector3 boundsCenter)
        {
            var maxZ = new Vector3(boundsCenter.x, boundsCenter.y, Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(maxZ);
        }
        
        private Vector3 GetMinZ(Vector3 boundsCenter)
        {
            var minZ = new Vector3(boundsCenter.x, boundsCenter.y, -Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(minZ);
        }
    }
}