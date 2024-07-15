using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action onLoad = null) =>
            _coroutineRunner.StartCoroutine(SceneLoading(sceneName, onLoad));

        public IEnumerator SceneLoading(string sceneName, Action onLoad = null)
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            yield return new WaitUntil(() => loading.isDone);
            onLoad?.Invoke();
        }
    }
}
