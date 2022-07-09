using System;
using UnityEngine;

namespace Utils.Selection
{
    public static class SelectionUtilities
    {
        public static bool CheckRectangleHit(Camera camera, Vector3 position, Vector3 start, Vector3 end)
        {
            var calculator = new CalculatorOfSelectedObjects(camera);
            var viewportBounds = calculator.GetViewportBounds(start, end);
            return viewportBounds.Contains(camera.WorldToViewportPoint(position));
        }

        public static void ChangeStateSelector(GameObject selector, bool state)
        {
            if (selector == null)
                throw new Exception("selector not selected");
            selector.SetActive(state);
        }
    }
}