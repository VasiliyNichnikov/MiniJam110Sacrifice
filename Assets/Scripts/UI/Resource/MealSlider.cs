using Economy.Resource;

namespace UI.Resource
{
    public class MealSlider : ResourceSliderChanger
    {
        protected override void AddResource(int value, IResource resource)
        {
            if(resource is IMeal)
                base.AddResource(value, resource);
        }

        protected override void SubtractResource(int value, IResource resource)
        {
            if(resource is IMeal)
                base.SubtractResource(value, resource);
        }
    }
}