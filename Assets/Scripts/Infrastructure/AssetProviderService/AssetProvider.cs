using Gameplay.Level;
using UnityEngine;

namespace Infrastructure.AssetProviderService
{
    public class AssetProvider : IAssets
    {
        public TCreatable Instantiate<TCreatable>(string path, Transform parent) where TCreatable : Object
        {
            TCreatable prefab = Load<TCreatable>(path);
            return Object.Instantiate(prefab, parent);
        }

        public TCreatable Instantiate<TCreatable>(string path, Vector3 at) where TCreatable : Object
        {
            TCreatable prefab = Load<TCreatable>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public TCreatable Instantiate<TCreatable>(string path) where TCreatable : Object
        {
            TCreatable prefab = Load<TCreatable>(path);
            return Object.Instantiate(prefab);
        }

        public TCreatable Instantiate<TCreatable>(string path, Vector3 position, Quaternion rotation, Transform parent) where TCreatable : Object
        {
            TCreatable prefab = Load<TCreatable>(path);
            return Object.Instantiate(prefab, position, rotation, parent);
        }

        private TCreatable Load<TCreatable>(string path) where TCreatable : Object => 
            Resources.Load<TCreatable>(path);
    }
}