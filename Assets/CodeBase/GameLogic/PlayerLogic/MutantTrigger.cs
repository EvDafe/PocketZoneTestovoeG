using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    [RequireComponent(typeof(Collider2D))]
    public class MutantTrigger : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Mutant.Mutant> PlayerEntered;
        public event Action<Mutant.Mutant> PlayerExit;

        private void OnValidate() =>
            _collider ??= GetComponent<Collider2D>();

        private void Awake() =>
            _collider.isTrigger = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Mutant.Mutant player))
            {
                Debug.Log("PlayerEntered");
                PlayerEntered?.Invoke(player);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Mutant.Mutant player))
            {
                Debug.Log("PlayerExit");
                PlayerExit?.Invoke(player);
            }
        }
    }
}
