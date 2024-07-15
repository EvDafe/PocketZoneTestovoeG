using Assets.CodeBase.GameLogic.Inventory;
using Assets.CodeBase.GameLogic.PlayerLogic;
using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class Mutant : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private PlayerTrigger _attackRange;
        [SerializeField] private PlayerTrigger _fieldOfView;
        [SerializeField] private RandomItemDrop _randomItemDrop;

        private PlayerLogic.Player _player;
        private MutantHealth _health;
        private MutantStateMachine _stateMachine;
        private ItemsDataContainer _itemsDataContainer;

        public MutantHealth Health => _health;
        public float Speed => _speed;
        public float Damage => _damage;
        public float AttackCooldown => _attackCooldown;

        public event Action Dead;
        public event Action Initialized;

        private void FixedUpdate() => 
            _stateMachine?.Tick(Time.fixedDeltaTime);

        private void Death()
        {
            var yes = Instantiate(_randomItemDrop, transform.position, Quaternion.identity);
            yes.Initialize(_itemsDataContainer);
            Dead?.Invoke();
            Destroy(gameObject);
        }

        public void Initialize(Player player, ItemsDataContainer itemsDataContainer)
        {
            _itemsDataContainer = itemsDataContainer;
            _player = player;
            _health = new(_maxHealth);
            _stateMachine = new(this, _player, _fieldOfView, _attackRange);
            _stateMachine.Enter<WaitPlayerState>();
            _health.Dead += Death;
            Initialized?.Invoke();
        }
    }
}
