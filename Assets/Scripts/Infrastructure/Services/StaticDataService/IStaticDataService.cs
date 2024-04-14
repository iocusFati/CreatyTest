using Infrastructure.StaticData.PlayerData;

namespace Infrastructure.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        PlayerConfig PlayerConfig { get; }
    }
}