using ObjectUnity;
using UnityEngine;

namespace Builders
{
    [RequireComponent(typeof(RequireComponent))]
    public class Foundation : MonoBehaviour
    {
        private IBoundary _boundary;
        private void Start()
        {
            var render = GetComponent<MeshRenderer>();
            _boundary = new CalculatorBoundaryCorners(render);
            
            // var cells = EventsManager.GetPointsInZone(new Vector2(_boundary.Left.x, _boundary.Left.z), 
            // new Vector2(_boundary.Right.x, _boundary.Right.z));
            
        }
        
    }
}