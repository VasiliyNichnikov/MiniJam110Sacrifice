using UnityEngine;

namespace ClickObjects
{
    public class Ground: MonoBehaviour, IClickObject
    {
        public bool IsGround => true;
    }
}