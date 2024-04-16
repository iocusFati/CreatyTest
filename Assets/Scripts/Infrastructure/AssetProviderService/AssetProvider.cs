using Gameplay.Level;
using UnityEngine;
using Zenject;

namespace Infrastructure.AssetProviderService
{
    public class AssetProvider : IAssets
    {
        private readonly IInstantiator _instantiator;
        private GameObject _sceneRoot;

        public AssetProvider(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TCreatable Instantiate<TCreatable>(string path, Transform parent) where TCreatable : Component
        {
            TCreatable instance = _instantiator.InstantiatePrefabResourceForComponent<TCreatable>(path, parent);
            return instance;
        }

        public TCreatable Instantiate<TCreatable>(string path, Vector3 at) where TCreatable : Component
        {
            TCreatable instance = _instantiator.InstantiatePrefabResourceForComponent<TCreatable>(path);
            instance.transform.position = at;
            SetParentToScene(instance.transform);
            return instance;
        }

        public TCreatable Instantiate<TCreatable>(string path) where TCreatable : Component
        {
            TCreatable instance = _instantiator.InstantiatePrefabResourceForComponent<TCreatable>(path);
            SetParentToScene(instance.transform);
            return instance;
        }

        public TCreatable Instantiate<TCreatable>(string path, Vector3 position, Quaternion rotation, Transform parent) where TCreatable : Component
        {
            TCreatable instance = _instantiator.InstantiatePrefabResourceForComponent<TCreatable>(path, position, rotation, parent);
            
            return instance;
        }

        private void SetParentToScene(Transform transform)
        {
            if (_sceneRoot == null)
                _sceneRoot = new GameObject("SceneRoot");
            
            if (_sceneRoot != null) 
                transform.SetParent(_sceneRoot.transform);
        }
    }
}