using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!waitNextSceneAsync.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}    