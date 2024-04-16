using System.Collections;
using Infrastructure;
using Infrastructure.Services.StaticDataService;
using Infrastructure.States;
using Infrastructure.StaticData.Game;
using UnityEngine;

namespace Gameplay.Level.Plot
{
    public class Timer
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameConfig _gameConfig;
        private readonly IUIMediator _uiMediator;
        
        private bool _isPaused;

        public Timer(ICoroutineRunner coroutineRunner, IUIMediator uiMediator, IStaticDataService staticData)
        {
            _coroutineRunner = coroutineRunner;
            _gameConfig = staticData.GameConfig;
            _uiMediator = uiMediator;
        }

        public void ResetTimer()
        {
            _coroutineRunner.StartCoroutine(RunTimer());
        }

        private IEnumerator RunTimer()
        {
            int time = _gameConfig.LevelTime;
            _uiMediator.UpdateTimer(time);

            while (time > 0)
            {
                yield return new WaitForSeconds(1);

                if (_isPaused)
                {
                    yield return null;
                    continue;
                }

                time--;
                _uiMediator.UpdateTimer(time);
            }
        }
        public void Pause(bool pause) => 
            _isPaused = pause;
    }
}