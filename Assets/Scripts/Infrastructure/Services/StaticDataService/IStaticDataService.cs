using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.PlayerData;
using Infrastructure.StaticData.UI;

namespace Infrastructure.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        PlayerConfig PlayerConfig { get; }
        LocationConfig LocationConfig { get; }
        LevelPlotConfig LevelPlotConfig { get; }
        UIConfig UIConfig { get; }
    }
}