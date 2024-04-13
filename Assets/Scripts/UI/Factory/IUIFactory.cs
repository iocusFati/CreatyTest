using Base.UI.Entities;
using Infrastructure.Services;

namespace Base.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateGameUIRoot();
        HUD CreateHUD();
    }
}