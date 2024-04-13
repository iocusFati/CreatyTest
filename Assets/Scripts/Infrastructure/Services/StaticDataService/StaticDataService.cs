using Infrastructure.AssetProviderService;
using Infrastructure.StaticData.PlayerData;
using UnityEngine;

namespace Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        public PlayerStaticData PlayerData { get; set; }

        public void Initialize()
        {
            InitializePlayerData();
        }

        private void InitializePlayerData()
        {
            PlayerData = Resources.Load<PlayerStaticData>(AssetPaths.PlayerData);
        }
    }
}