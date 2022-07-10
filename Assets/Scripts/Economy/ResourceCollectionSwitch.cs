using UnityEngine;

namespace Economy
{
    public class ResourceCollectionSwitch: MonoBehaviour
    {
        [SerializeField, Header("Описание построек и ресурса, который добавается в постройке")]
        private ParameterResource[] _parametersResource;

        private void Start()
        {
            StartCheckCollection();
        }

        private void StartCheckCollection()
        {
            foreach (var buildersAndResource in _parametersResource)
            {
                var collectionOfResources = new CollectionOfResources(buildersAndResource);
                StartCoroutine(collectionOfResources.RunProfitCheck());
            }
        }
    }
}