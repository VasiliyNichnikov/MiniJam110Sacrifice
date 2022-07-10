using UnityEngine;

namespace ClickObjects
{
    public class Ground: MonoBehaviour, IClickObject
    {
        public bool IsClick => true;
        public bool IsWork => false;
    }
}