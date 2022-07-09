using UnityEngine;

namespace ManagementOfSettlers.UnitActions
{
    public abstract class UnitAction : MonoBehaviour
    {
        public virtual void Action()
        {
        }

        public virtual void Action(object parameter)
        {
        }
    }
}