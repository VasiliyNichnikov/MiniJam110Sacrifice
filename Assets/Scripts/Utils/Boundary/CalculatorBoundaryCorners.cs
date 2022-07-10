using UnityEngine;

namespace Utils.Boundary
{
    public class CalculatorBoundaryCorners: IBoundary
    {
        public Vector3 Right { get; }
        public Vector3 Left { get; }
        public Vector3 Forward { get; }
        public Vector3 Back { get; }
        public float LengthX { get; }
        public float LengthZ { get; }

        private readonly MeshRenderer _renderer;

        public CalculatorBoundaryCorners(MeshRenderer renderer)
        {
            _renderer = renderer;

            var boundsCenter = renderer.bounds.center;
            Right = GetRightCorner(boundsCenter);
            Left = GetLeftCorner(boundsCenter);
            Forward = GetForwardCorner(boundsCenter);
            Back = GetBackCorner(boundsCenter);

            LengthX = Right.x - Left.x;
            LengthZ = Forward.x - Back.x;
        }

        private Vector3 GetRightCorner(Vector3 boundsCenter)
        {
            var right = new Vector3(Mathf.Infinity, boundsCenter.y, Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(right);
        }
        
        private Vector3 GetLeftCorner(Vector3 boundsCenter)
        {
            var left = new Vector3(-Mathf.Infinity, boundsCenter.y, -Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(left);
        }
        
        private Vector3 GetForwardCorner(Vector3 boundsCenter)
        {
            var forward = new Vector3(-Mathf.Infinity, boundsCenter.y, Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(forward);
        }
        
        private Vector3 GetBackCorner(Vector3 boundsCenter)
        {
            var back = new Vector3(Mathf.Infinity, boundsCenter.y, -Mathf.Infinity);
            return _renderer.bounds.ClosestPoint(back);
        }
    }
}