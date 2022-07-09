using UnityEngine;
using Utils.Boundary;

namespace SettlementObjects.Builders
{
    [RequireComponent(typeof(RequireComponent))]
    public class Foundation : MonoBehaviour
    {
        private IBoundary _boundary;
        private void Start()
        {
            var render = GetComponent<MeshRenderer>();
            _boundary = new CalculatorBoundaryCorners(render);

        }
        
    }
}