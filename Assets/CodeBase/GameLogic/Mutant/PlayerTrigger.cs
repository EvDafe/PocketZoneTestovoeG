using Assets.CodeBase.GameLogic.PlayerLogic;
using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Mutant
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Player> PlayerEntered;
        public event Action<Player> PlayerExit;

        private void OnValidate() => 
            _collider ??= GetComponent<Collider2D>();

        private void Awake() => 
            _collider.isTrigger = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                Debug.Log("PlayerEntered");
                PlayerEntered?.Invoke(player);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                Debug.Log("PlayerExit");
                PlayerExit?.Invoke(player);
            }
        }
    }
}
