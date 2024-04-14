using Infrastructure.AssetProviderService;
using Infrastructure.StaticData.PlayerData;
using UnityEngine;

namespace Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        public PlayerConfig PlayerConfig { get; set; }

        public StaticDataService()
        {
            Initialize();
        }

        public void Initialize()
        {
            InitializePlayerConfig();
        }

        private void InitializePlayerConfig() => 
            PlayerConfig = Resources.Load<PlayerConfig>(AssetPaths.PlayerConfig);
    }
}