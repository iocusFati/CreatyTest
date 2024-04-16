using System;
using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.States
{
    public interface IGameFactory : IService
    {
        event Action<Player> OnPlayerCreated;
        void CreatePlayer(Vector3 at);
        LevelLocation CreateLevelLocation();
        Key CreateKey(Vector3 position, Transform keyParent);
    }
}