using Infrastructure.AssetProviderService;
using Infrastructure.StaticData.Game;
using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.PlayerData;
using Infrastructure.StaticData.UI;
using UnityEngine;

namespace Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        public PlayerConfig PlayerConfig { get; private set; }
        public LocationConfig LocationConfig { get; private set; }
        public LevelPlotConfig LevelPlotConfig { get; private set; }
        public UIConfig UIConfig { get; private set; }
        public GameConfig GameConfig { get; private set; }

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
            InitializeGameConfig();
        }

        private void InitializePlayerConfig() => 
            PlayerConfig = Resources.Load<PlayerConfig>(AssetPaths.PlayerConfig);
        
        private void InitializeLocationConfig() => 
            LocationConfig = Resources.Load<LocationConfig>(AssetPaths.LocationConfig);
        
        private void InitializeLevelPlotConfig() =>
            LevelPlotConfig = Resources.Load<LevelPlotConfig>(AssetPaths.LevelPlotConfig);

        private void InitializeUIConfig() =>
            UIConfig = Resources.Load<UIConfig>(AssetPaths.UIConfig);

        private void InitializeGameConfig() =>
            GameConfig = Resources.Load<GameConfig>(AssetPaths.GameConfig);
    }
}