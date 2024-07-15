using Assets.CodeBase.GameLogic.PlayerLogic;
using Assets.CodeBase.GameLogic.Yes;
using Assets.Scripts.Infrastructure.States;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class AttackPlayerState : IState, ITickable
    {
        private readonly Mutant _mutant;
        private readonly PlayerTrigger _attackCollider;
        private readonly Player _player;
        private readonly MutantStateMachine _stateMachine;

        private float _currentAttackCooldown;

        public AttackPlayerState(Mutant mutant, PlayerTrigger attackCollider, Player player, MutantStateMachine stateMachine)
        {
            _mutant = mutant;
            _attackCollider = attackCollider;
            _player = player;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _currentAttackCooldown = _mutant.AttackCooldown / 2;
            _attackCollider.PlayerExit += OnPlayerExit;
        }

        private void OnPlayerExit(Player obj) => 
            _stateMachine.Enter<MoveToPlayerState>();

        public void Exit() => 
            _attackCollider.PlayerExit -= OnPlayerExit;

        private void Attack()
        {
            _currentAttackCooldown = _mutant.AttackCooldown;
            _player.Health.TakeDamage(_mutant.Damage);
        }

        public void Tick(float delta)
        {
            _currentAttackCooldown -= delta;
            if (_currentAttackCooldown <= 0)
                Attack();
        }
    }
}