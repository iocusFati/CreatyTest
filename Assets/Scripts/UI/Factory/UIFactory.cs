using Infrastructure.AssetProviderService;
using UnityEngine;
using Zenject;

namespace Base.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssets _assets;
        private UIHolder _uiContainer;

        private const int HudCanvasOrder = 1;
        
        private Canvas _gameRoot;

        [Inject]
        public UIFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void Initialize(UIHolder uiHolder) => 
            _uiContainer = uiHolder;

        public void CreateGameUIRoot() => 
            _gameRoot = CreateUIRoot("GameRoot");

        public HUD CreateHUD()
        {
            Canvas hudCanvas = CreateUIRoot("HUD", HudCanvasOrder);

            HUD hud = CreateUIEntity<HUD>(AssetPaths.HUD, hudCanvas);

            return hud;
        }

        private TEntity CreateUIEntity<TEntity>(string path, Canvas parent = null) where TEntity : Component, IUIEntity
        {
            parent = SetParentIfNull();

            TEntity entity = _assets.Instantiate<TEntity>(path, parent.transform);
            _uiContainer.RegisterUIEntity(entity);

            return entity;

            Canvas SetParentIfNull()
            {
                if (parent is not null) 
                    return parent;
                
                if (_gameRoot == null)
                    CreateGameUIRoot();
                else
                    parent = _gameRoot;

                return parent;
            }
        }

        private Canvas CreateUIRoot(string name, int order = 0)
        {
            Canvas canvas = _assets.Instantiate<Canvas>(AssetPaths.UIRoot);
            canvas.name = name;
            canvas.sortingOrder = order;

            return canvas;
        }
    }
}