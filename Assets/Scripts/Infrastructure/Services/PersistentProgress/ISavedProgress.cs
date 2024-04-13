using Infrastructure.Data;

namespace UI.Entities
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}