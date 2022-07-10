using Economy.Resource;
using UnityEngine;

namespace UI.Resource
{
    public class ConstructionSlider : ResourceSliderChanger
    {
        protected override void AddResource(int value, IResource resource)
        {
            if(resource is IConstruction)
                base.AddResource(value, resource);
        }

        protected override void SubtractResource(int value, IResource resource)
        {
            if(resource is IConstruction)
                base.SubtractResource(value, resource);
        }
    }
}