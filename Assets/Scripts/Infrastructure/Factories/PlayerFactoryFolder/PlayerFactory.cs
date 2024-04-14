using Cinemachine;
using Infrastructure.AssetProviderService;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IInstantiator _instantiator;

        public PlayerFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void CreatePlayer(Vector3 at)
        {
            Player player = _instantiator.InstantiatePrefabResourceForComponent<Player>(AssetPaths.Player, at,
                Quaternion.identity, null);

            GetActiveCinemachineCamera().Follow = player.transform;
        }
        
        public ICinemachineCamera GetActiveCinemachineCamera()
        {
            CinemachineBrain activeBrain = CinemachineCore.Instance.GetActiveBrain(0);
            return activeBrain.ActiveVirtualCamera;
        }
    }
}