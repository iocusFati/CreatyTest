using Infrastructure.StaticData.PlayerData;

namespace Infrastructure.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        PlayerStaticData PlayerData { get; set; }
    }
}