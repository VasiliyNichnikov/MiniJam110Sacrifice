using UnityEngine;

namespace Utils.Selection
{
    public class CalculatorOfSelectedObjects
    {
        private readonly Camera _camera;

        public CalculatorOfSelectedObjects(Camera camera)
        {
            _camera = camera;
        }

        public Bounds GetViewportBounds(Vector3 start, Vector3 end)
        {
            var viewportStart = _camera.ScreenToViewportPoint(start);
            var viewportEnd = _camera.ScreenToViewportPoint(end);
            var min = Vector3.Min(viewportStart, viewportEnd);
            var max = Vector3.Max(viewportStart, viewportEnd);
            min.z = _camera.nearClipPlane;
            max.z = _camera.farClipPlane;

            Bounds bounds = new Bounds();
            bounds.SetMinMax(min, max);
            return bounds;
        }
    }
}