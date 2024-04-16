using Infrastructure.AssetProviderService;
using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.PlayerData;
using Infrastructure.StaticData.UI;
using UnityEngine;

namespace Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        public PlayerConfig PlayerConfig { get; set; }
        public LocationConfig LocationConfig { get; set; }
        public LevelPlotConfig LevelPlotConfig { get; set; }
        public UIConfig UIConfig { get; set; }

        public StaticDataService()
        {
            Initialize();
        }

        public void Initialize()
        {
            InitializePlayerConfig();
            InitializeLocationConfig();
            InitializeLevelPlotConfig();
            InitializeUIConfig();
        }

        private void InitializePlayerConfig() => 
            PlayerConfig = Resources.Load<PlayerConfig>(AssetPaths.PlayerConfig);
        
        private void InitializeLocationConfig() => 
            LocationConfig = Resources.Load<LocationConfig>(AssetPaths.LocationConfig);
        
        private void InitializeLevelPlotConfig() =>
            LevelPlotConfig = Resources.Load<LevelPlotConfig>(AssetPaths.LevelPlotConfig);
        
        public void InitializeUIConfig() =>
            UIConfig = Resources.Load<UIConfig>(AssetPaths.UIConfig);
    }
}