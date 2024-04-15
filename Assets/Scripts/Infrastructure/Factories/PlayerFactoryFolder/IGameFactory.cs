using Gameplay.Level;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.States
{
    public interface IGameFactory : IService
    {
        void CreatePlayer(Vector3 at);
        LevelLocation CreateLevelLocation();
        Key CreateKey(Vector3 position, Transform keyParent);
    }
}