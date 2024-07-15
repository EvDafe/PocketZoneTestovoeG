using System;

namespace Assets.CodeBase.GameLogic.Health
{
    public abstract class Health : IHealth
    {
        private float _currentHealth;
        private float _maxHealth;

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;

        public event Action DamageTaken;
        public event Action Dead;

        public Health(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public virtual void Death() =>
            Dead?.Invoke();

        public virtual void TakeDamage(float damage)
        {
            if (damage < 0) throw new ArgumentException("Ебать ты слабак", nameof(damage));

            _currentHealth -= damage;
            DamageTaken?.Invoke();
            if (_currentHealth <= 0)
                Death();
        }
    }
}
