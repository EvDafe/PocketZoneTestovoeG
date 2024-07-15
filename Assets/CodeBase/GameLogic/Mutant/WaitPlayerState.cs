using Assets.CodeBase.GameLogic.PlayerLogic;
using Assets.Scripts.Infrastructure.States;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class WaitPlayerState : IState
    {
        private readonly PlayerTrigger _trigger;
        private readonly MutantStateMachine _stateMachine;

        public WaitPlayerState(PlayerTrigger trigger, MutantStateMachine stateMachine)
        {
            _trigger = trigger;
            _stateMachine = stateMachine;
        }

        public void Enter() => 
            _trigger.PlayerEntered += OnPlayerEnter;

        private void OnPlayerEnter(Player player) => 
            _stateMachine.Enter<MoveToPlayerState>();

        public void Exit() => 
            _trigger.PlayerEntered -= OnPlayerEnter;
    }
}
