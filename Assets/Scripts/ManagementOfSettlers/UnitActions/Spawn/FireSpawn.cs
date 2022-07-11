using ManagementOfSettlers.UnitSelection.Buffer;
using UnityEngine;

namespace ManagementOfSettlers.UnitActions.Spawn
{
    public class FireSpawn : MonoBehaviour
    {
        [SerializeField, Header("Точка в которой будут появляться новые поселенцы")] 
        private Transform _pointOfCreationSettler;
        
        [SerializeField, Header("Буфер, содержит в себе всех юнитов и постройки")]
        private BufferOfSelectedObjects _buffer;

        public void CreateSettler(ICreatorUnit creator)
        {
            var settler = creator.Create(_pointOfCreationSettler.position, Quaternion.identity);
            _buffer.Add(settler);
        }
        
    }
}