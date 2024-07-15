namespace Assets.CodeBase.GameLogic.Health
{
    public interface IHealth
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public void TakeDamage(float damage);
        public void Death();
    }
}
