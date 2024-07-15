using Assets.CodeBase.GameLogic.PlayerLogic;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Inventory
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _force;
        [SerializeField] private MutantTrigger _trigger;

        private float _damage;

        private void OnValidate() => 
            _rigidBody ??= GetComponent<Rigidbody2D>();

        public void Initialize(float damage)
        {
            _damage = damage;
            _rigidBody.AddForce(Vector2.right * _force);
            _trigger.PlayerEntered += OnEnter;
        }

        private void OnEnter(Mutant.Mutant mutant)
        {
            mutant.Health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
