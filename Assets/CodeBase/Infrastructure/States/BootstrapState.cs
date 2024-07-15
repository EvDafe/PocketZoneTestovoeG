using Assets.Scripts.ServicesScripts.Progress;
using Assets.Scripts.ServicesScripts;
using Assets.CodeBase.GameLogic.Inventory;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            RegisterServices();
            Services.Container.Get<SceneLoadService>().LoadScene<GameLoopState>("GameScene");
        }

        private void RegisterServices()
        {
            var loadingService = new LoadProgressService();
            Services.Container.Register<LoadProgressService>(loadingService).Load();
            Services.Container.Register<SceneLoadService>(new SceneLoadService(_gameStateMachine));
            Services.Container.Register<InventoryService>(new InventoryService(loadingService));
        }

        public void Exit()
        { }
    }
}
