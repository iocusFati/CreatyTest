using Gameplay.Level;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetProviderService
{
    public interface IAssets : IService
    {
        TCreatable Instantiate<TCreatable>(string path, Transform parent) where TCreatable : Component;
        TCreatable Instantiate<TCreatable>(string path, Vector3 at) where TCreatable : Component;
        TCreatable Instantiate<TCreatable>(string path) where TCreatable : Component;
        TCreatable Instantiate<TCreatable>(string path, Vector3 position, Quaternion rotation, Transform parent) where TCreatable : Component;
    }
}