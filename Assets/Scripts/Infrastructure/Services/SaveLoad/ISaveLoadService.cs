using Infrastructure.Data;
using UI.Entities;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
        void Register(ISavedProgressReader reader);
        void InformReaders();
    }
}