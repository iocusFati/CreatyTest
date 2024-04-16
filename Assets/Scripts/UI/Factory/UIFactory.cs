using Infrastructure.AssetProviderService;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Base.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssets _assets;

        private const int HudCanvasOrder = 1;
        
        private Canvas _gameRoot;


        public UIFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreateGameUIRoot() => 
            _gameRoot = CreateUIRoot("GameRoot");

        public DialogueWindow CreateDialogueWindow() => 
            CreateUIEntity<DialogueWindow>(AssetPaths.DialogueWindow);

        public HUD CreateHUD()
        {
            Canvas hudCanvas = CreateUIRoot("HUD", HudCanvasOrder);

            HUD hud = CreateUIEntity<HUD>(AssetPaths.HUD, hudCanvas);

            return hud;
        }

        private TEntity CreateUIEntity<TEntity>(string path, Canvas parent = null) where TEntity : Component
        {
            parent = SetParentIfNull();

            TEntity entity = _assets.Instantiate<TEntity>(path, parent.transform);

            return entity;

            Canvas SetParentIfNull()
            {
                if (parent is not null) 
                    return parent;
                
                if (_gameRoot == null)
                    CreateGameUIRoot();

                return _gameRoot;
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