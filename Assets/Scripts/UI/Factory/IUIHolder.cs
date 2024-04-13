using Infrastructure.Services;

namespace Base.UI.Factory
{
    public interface IUIHolder : IService
    {
        TUIEntity Single<TUIEntity>() where TUIEntity : IUIEntity;
    }
}