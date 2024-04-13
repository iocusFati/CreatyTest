using Infrastructure.AssetProviderService;
using UnityEngine;

namespace Infrastructure.States
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IAssets _assets;

        public PlayerFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreatePlayer(Vector3 at)
        {
            _assets.Instantiate<Player>(AssetPaths.Player, at);
        }
    }
}