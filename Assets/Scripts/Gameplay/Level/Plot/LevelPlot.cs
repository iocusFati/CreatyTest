using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Level.Location;
using Gameplay.Level.Plot;
using Infrastructure.Services.Input;
using Infrastructure.StaticData.Level;

namespace Infrastructure.States
{
    public class LevelPlot
    {
        private readonly Dialogue _dialogue;
        private readonly IInputService _inputService;
        private readonly CameraStates _cameraStates;
        private readonly LevelLocation _location;
        private readonly IUIMediator _uiMediator;
        private readonly Timer _timer;

        private Player _player;

        public LevelPlot(IUIMediator uiMediator, IInputService inputService, IGameFactory gameFactory,
            CameraStates cameraStates, LevelLocation location, Timer timer)
        {
            _uiMediator = uiMediator;
            _inputService = inputService;
            _cameraStates = cameraStates;
            _location = location;
            _timer = timer;

            _dialogue = new Dialogue(uiMediator);
            
            gameFactory.OnPlayerCreated += player => _player = player;
        }

        public async UniTask StartPlot(List<PlotItem> plot)
        {
            _player.DisableInput();
            _timer.Pause(true);
            _uiMediator.HideHUD();
            
            for (var index = 0; index < plot.Count; index++)
            {
                if (ShouldHideDialogue(index)) 
                    _dialogue.HideDialogue();

                await ExecutePlotItem(plot[index]);
            }
            
            _dialogue.HideDialogue();
            _player.EnableInput();
            _timer.Pause(false);
            _uiMediator.ShowHUD();
            
            bool ShouldHideDialogue(int index) => 
                index > 0 
                && plot[index - 1].Type == PlotItemType.Dialogue 
                && plot[index].Type != PlotItemType.Dialogue;
        }

        private async UniTask ExecutePlotItem(PlotItem plotItem)
        {
            switch (plotItem.Type)
            {
                case PlotItemType.Dialogue:
                    _dialogue.StartDialogue(plotItem.DialogueVerse);
                    
                    await WaitUntillPressEnter();
                    
                    break;
                case PlotItemType.CameraStateSwitch:
                    await _cameraStates.SwitchCameraState(plotItem.CameraState);
                        
                    break;
                case PlotItemType.Action:
                    ExecuteActionPlotItem(plotItem);
                    break;
            }
        }

        private void ExecuteActionPlotItem(PlotItem plotItem)
        {
            switch (plotItem.ActionType)
            {
                case PlotActionType.OpenDoor:
                    _location.OpenDoor();
                    break;
            }
        }

        private UniTask WaitUntillPressEnter() => 
            UniTask.WaitUntil(() => _inputService.PressEnter());
    }
}