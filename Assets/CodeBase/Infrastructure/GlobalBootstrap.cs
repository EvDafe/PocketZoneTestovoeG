using UnityEngine;
using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure
{
    public class GlobalBootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private GameStateMachine _gameStateMachine;

        public void Awake()
        {
            DontDestroyOnLoad(this);
            _gameStateMachine = new(this, _loadingCurtain);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
