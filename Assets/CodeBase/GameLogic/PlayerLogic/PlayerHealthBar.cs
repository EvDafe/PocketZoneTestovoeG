using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private Player _player;
        private PlayerHealth _playerHealth;

        [Inject]
        private void Construct(Player player) =>
            _player = player;

        private void Start()
        {
            _playerHealth = _player.Health;
            _playerHealth.DamageTaken += UpdateBar;
        }

        private void UpdateBar() => 
            _image.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
    }
}
