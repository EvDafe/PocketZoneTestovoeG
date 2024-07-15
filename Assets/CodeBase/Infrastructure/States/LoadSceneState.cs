using System;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadSceneState : IDoublePayLoadedState<string, Action>
    {
        private SceneLoader _sceneLoader;
        private GameStateMachine _gameStateMachine;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadSceneState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = new(coroutineRunner);
        }

        public void Enter(string sceneName, Action onLoad = null)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(sceneName, onLoad);
        }

        public void Enter<TNextState>(string sceneName, Action onLoad = null) where TNextState : class, IState
        {
            onLoad += GoToNextState<TNextState>;
            _gameStateMachine.Enter<LoadSceneState, string, Action>(sceneName, onLoad);
        }

        private void GoToNextState<TState>() where TState : class, IState => 
            _gameStateMachine.Enter<TState>();

        public void Exit() => 
            _loadingCurtain.Hide();
    }
}
