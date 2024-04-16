using System;
using Cinemachine;
using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure.AssetProviderService;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public event Action<Player> OnPlayerCreated;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreatePlayer(Vector3 at)
        {
            Player player = _assets.Instantiate<Player>(AssetPaths.Player, at);
            PlusOneText plusOneText = _assets.Instantiate<PlusOneText>(AssetPaths.PlusOneText);
            
            player.PlusOneText = plusOneText;

            GetActiveCinemachineCamera().Follow = player.transform;
            
            OnPlayerCreated?.Invoke(player);
        }

        public LevelLocation CreateLevelLocation() => 
            _assets.Instantiate<LevelLocation>(AssetPaths.Location);

        public Key CreateKey(Vector3 position, Transform keyParent) => 
            _assets.Instantiate<Key>(AssetPaths.Key, position, Quaternion.identity, keyParent);

        private ICinemachineCamera GetActiveCinemachineCamera()
        {
            CinemachineBrain activeBrain = CinemachineCore.Instance.GetActiveBrain(0);
            CinemachineStateDrivenCamera stateDrivenCamera = activeBrain.ActiveVirtualCamera as CinemachineStateDrivenCamera;
    
            return stateDrivenCamera != null ? stateDrivenCamera.LiveChild : null;        }
    }
}