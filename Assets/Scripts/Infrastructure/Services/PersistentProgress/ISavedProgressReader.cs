using Infrastructure.Data;

namespace UI.Entities
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}