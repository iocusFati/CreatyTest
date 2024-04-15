using Cinemachine;
using Gameplay.Level;
using Infrastructure.AssetProviderService;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssets _assets;

        public GameFactory(IInstantiator instantiator, IAssets assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }

        public void CreatePlayer(Vector3 at)
        {
            Player player = _instantiator.InstantiatePrefabResourceForComponent<Player>(AssetPaths.Player, at,
                Quaternion.identity, null);

            GetActiveCinemachineCamera().Follow = player.transform;
        }

        public LevelLocation CreateLevelLocation() => 
            _assets.Instantiate<LevelLocation>(AssetPaths.Location);

        public Key CreateKey(Vector3 position, Transform keyParent) => 
            _assets.Instantiate<Key>(AssetPaths.Key, position, Quaternion.identity, keyParent);

        private ICinemachineCamera GetActiveCinemachineCamera()
        {
            CinemachineBrain activeBrain = CinemachineCore.Instance.GetActiveBrain(0);
            return activeBrain.ActiveVirtualCamera;
        }
    }
}