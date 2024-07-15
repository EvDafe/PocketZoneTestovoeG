using Assets.CodeBase.GameLogic.PlayerLogic;
using Assets.CodeBase.GameLogic.Yes;
using Assets.Scripts.Infrastructure.States;
using System;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class MoveToPlayerState : IState, ITickable
    {
        private readonly Player _player;
        private readonly MutantStateMachine _stateMachine;
        private readonly Mutant _mutant;
        private readonly PlayerTrigger _attackRange;
        private readonly PlayerTrigger _fieldOfView;

        public MoveToPlayerState(Player player, MutantStateMachine stateMachine, Mutant mutant, PlayerTrigger attackRange, PlayerTrigger fieldOfView)
        {
            _player = player;
            _stateMachine = stateMachine;
            _mutant = mutant;
            _attackRange = attackRange;
            _fieldOfView = fieldOfView;
        }

        public void Enter()
        {
            _fieldOfView.PlayerExit += OnPlayerExit;
            _attackRange.PlayerEntered += OnPlayerEnter;
        }

        private void OnPlayerExit(Player obj) => 
            _stateMachine.Enter<WaitPlayerState>();

        private void OnPlayerEnter(Player player) => 
            _stateMachine.Enter<AttackPlayerState>();

        public void Tick(float delta) => 
            MoveToPlayer(delta);

        private void MoveToPlayer(float delta)
        {
            var direction = (_player.transform.position - _mutant.transform.position).normalized;
            _mutant.transform.position += direction * _mutant.Speed * delta;
        }

        public void Exit() => 
            _attackRange.PlayerEntered -= OnPlayerEnter;
    }
}
